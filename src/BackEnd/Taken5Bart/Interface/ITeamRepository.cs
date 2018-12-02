using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();
        Team GetTeam(int Id);
        void UpdateTeam(Team newTeam);
        Team NewTeam(Team t);
    }
}
