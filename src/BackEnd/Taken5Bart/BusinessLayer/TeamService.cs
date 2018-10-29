using System;
using System.Collections.Generic;
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
        public TeamService(GameContext context)
        {
            teamRepo = new TeamRepository(context);
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
