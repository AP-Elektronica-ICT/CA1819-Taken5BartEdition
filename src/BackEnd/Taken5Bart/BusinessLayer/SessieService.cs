using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;

namespace BusinessLayer.T5B
{
    public class SessieService : ISessieService
    {
        private ISessionRepository _sessieRepo;
        private ITeamRepository _teamRepo;
        private IGameRepository _gameRepo;
        private IPuzzelRepository _puzzelRepo;

        public SessieService(GameContext context)
        {
            _sessieRepo = new SessieRepository(context);
            _teamRepo = new TeamRepository(context);
            _gameRepo = new GameRepository(context);
            _puzzelRepo = new PuzzelRepository(context);
        }
        public SessieService(ISessionRepository sessieRepo, ITeamRepository teamRepo, IPuzzelRepository puzzelRepo)
        {
            _sessieRepo = sessieRepo;
            _teamRepo = teamRepo;
            _puzzelRepo = puzzelRepo;
        }

        public string CreateSessie(Sessie newSessie)
        {
            var newSessieCode = "-1";
            List<Team> teams = new List<Team>();
            List<Puzzel> puzzels = _puzzelRepo.GetPuzzels().ToList();
            int startpuzzel = 0;
            foreach(Team t in newSessie.Teams)
            {
                t.DiamantenVerzameld = 0;
                t.Score = 0;
                t.Spelers = null;
                t.TeamMode = 0;
                t.StartPuzzel = startpuzzel;
                
                var newT = _teamRepo.NewTeam(t);
                _teamRepo.AddPuzzels(newT, puzzels);

                teams.Add(newT);

                startpuzzel++;
            }
            newSessie.Teams = teams;
            newSessie.Code = RandomString(6);
            _sessieRepo.AddSessie(newSessie);
            newSessieCode = newSessie.Code;
            return newSessieCode;
        }

        public Sessie GetSessie(int id)
        {
            return _sessieRepo.GetSessie(id);
        }

        public Sessie GetSessieByCode(string code)
        {
            code = code.ToUpper();
            var sessies = _sessieRepo.GetSessies();
            Sessie sessie = sessies.Where(s => s.Code == code).SingleOrDefault();
            return sessie;
        }

        public ICollection<Sessie> GetSessies()
        {
            return _sessieRepo.GetSessies();
        }

        public ICollection<Team> GetTeamsBySessie(string sessieId)
        {
            var s = GetSessieByCode(sessieId);
            ICollection<Team> t = null;
            if(s != null)
            {
                t = s.Teams;
            }
            return t;
        }

        private static Random random = new Random();
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
