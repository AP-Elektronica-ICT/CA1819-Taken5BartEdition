using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        Team GetTeam(int Id);

        bool SpelerJoin(int spelerId, int teamId);
        void NewTeam(Team t);
    }
}
