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

        public SessieService(GameContext context)
        {
            _sessieRepo = new SessieRepository(context);
            _teamRepo = new TeamRepository(context);
            _gameRepo = new GameRepository(context);
        }
        public SessieService(ISessionRepository sessieRepo, ITeamRepository teamRepo)
        {
            _sessieRepo = sessieRepo;
            _teamRepo = teamRepo;
        }

        public int CreateSessie(Sessie newSessie)
        {
            var newSessieId = -1;
            List<Team> teams = new List<Team>();
            //var puzzels = _gameRepo.GetPuzzels()
            foreach(Team t in newSessie.Teams)
            {
                t.DiamantenVerzameld = 0;
                t.Score = 0;
                t.Spelers = null;
                //t.puzzels
                var newT = _teamRepo.NewTeamT(t);
                teams.Add(newT);
            }
            newSessie.Teams = teams;
            _sessieRepo.AddSessie(newSessie);
            newSessieId = newSessie.Id;
            return newSessieId;
        }

        public Sessie GetSessie(int id)
        {
            return _sessieRepo.GetSessie(id);
        }

        public ICollection<Sessie> GetSessies()
        {
            return _sessieRepo.GetSessies();
        }

        public ICollection<Team> GetTeamsBySessie(int sessieId)
        {
            var s = _sessieRepo.GetSessie(sessieId);
            ICollection<Team> t = null;
            if(s != null)
            {
                t = s.Teams;
            }
            return t;
        }
    }
}
