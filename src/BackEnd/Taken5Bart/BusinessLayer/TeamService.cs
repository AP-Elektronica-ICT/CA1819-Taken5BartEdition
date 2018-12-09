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
    public class TeamService : ITeamService
    {
        private ISpelerRepository _spelerRepo;
        private ITeamRepository _teamRepo;
        private ISessionRepository _sessieRepo;
        private IPuzzelRepository _puzzelRepo;

        public TeamService(GameContext context)
        {
            _teamRepo = new TeamRepository(context);
            _sessieRepo = new SessieRepository(context);
            _spelerRepo = new SpelerRepository(context);
            _puzzelRepo = new PuzzelRepository(context);
        }
        public TeamService(ITeamRepository teamRepo, ISpelerRepository spelerRepo, ISessionRepository sessieRepo, IPuzzelRepository puzzelRepo)
        {
            _teamRepo = teamRepo;
            _sessieRepo = sessieRepo;
            _spelerRepo = spelerRepo;
            _puzzelRepo = puzzelRepo;
        }

        public int GetScorePos(int id)
        {
            var team = _teamRepo.GetTeam(id);
            if (team == null)
            {
                return -1;
            }
            var sessie = team.AssignedSessie;
            if(sessie == null)
            {
                return -1;
            }
            int sessieId = sessie.Id;
            IQueryable<Team> q = _sessieRepo.GetSessie(sessieId).Teams.AsQueryable();
            q = q.OrderByDescending(t => t.Score);
            var result = q
            .Select((x, i) => new { Item = x, Index = i })
            .Where(itemWithIndex => itemWithIndex.Item.Id == id)
            .FirstOrDefault();
            return (result.Index+1);
        }

        public Team GetTeam(int id)
        {
            Team t = _teamRepo.GetTeam(id);
            return t;
        }

        public ICollection<Team> GetTeams()
        {
            var ts = _teamRepo.GetTeams();
            return ts;
        }

        public bool SpelerJoin(int spelerId, int teamId)
        {
            Speler speler = _spelerRepo.GetSpeler(spelerId);
            Team team = _teamRepo.GetTeam(teamId);
            if (speler == null || team == null)
            {
                return false;
            }
            team.Spelers.Add(speler);
            _teamRepo.UpdateTeam(team);
            return true;
        }
        public Puzzel ActivePuzzel(int Id)
        {
            var t = GetTeam(Id);
            if(t.ActivePuzzel == -1)
            {
                return null;
            }
            var p = _puzzelRepo.GetPuzzel(t.ActivePuzzel);
            return p;
            
        }

        public int ActivePuzzelID(int Id)
        {
            return GetTeam(Id).ActivePuzzel;
        }

        public Puzzel SetActivePuzzel(int Id)
        {
            var team = GetTeam(Id);
            var pl = team.PuzzelsTeam.ToList();
            Puzzel ActivePuzzel = _puzzelRepo.GetPuzzel(pl.ElementAt(team.DiamantenVerzameld).PuzzelId);
            _teamRepo.SetActivePuzzel(Id, ActivePuzzel.Id);
            return ActivePuzzel;
        }
    }
}
