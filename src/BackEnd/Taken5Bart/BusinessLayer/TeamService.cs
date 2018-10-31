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
        private ITeamRepository teamRepo;
        private ISessionRepository sessieRepo;

        public TeamService(GameContext context)
        {
            teamRepo = new TeamRepository(context);
            sessieRepo = new SessieRepository(context);
        }

        public int GetScorePos(int id)
        {
            var sessieId = teamRepo.GetTeam(id).AssignedSessie.Id;
            IQueryable<Team> q = sessieRepo.GetTeams(sessieId).AsQueryable();
            
            q = q.OrderByDescending(t => t.Score);
            var result = q
            .Select((x, i) => new { Item = x, Index = i })
            .Where(itemWithIndex => itemWithIndex.Item.Id == id)
            .FirstOrDefault();
            return result.Index;
        }

        public Team GetTeam(int id)
        {
            Team t = teamRepo.GetTeam(id);
            return t;
        }

        public IEnumerable<Team> GetTeams()
        {
            var ts = teamRepo.GetTeams();
            return ts;
        }
    }
}
