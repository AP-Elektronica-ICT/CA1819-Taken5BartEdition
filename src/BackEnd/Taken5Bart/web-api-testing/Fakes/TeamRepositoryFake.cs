using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using web_api_testing.Fakes;

namespace web_api_testing
{
    public class TeamRepositoryFake: ITeamRepository
    {
        private List<Team> _teams;

        public TeamRepositoryFake()
        {
            reset();
        }

        public void reset()
        {
            _teams = GameDBFake.teams;
            _teams[0].AssignedSessie = GameDBFake.sessies[0];
            _teams[1].AssignedSessie = GameDBFake.sessies[0];
            _teams[2].AssignedSessie = null;
            _teams[0].PuzzelsTeam.Add(GameDBFake.puzzelTeams[0]);
            _teams[0].PuzzelsTeam.Add(GameDBFake.puzzelTeams[1]);
            _teams[1].PuzzelsTeam.Add(GameDBFake.puzzelTeams[2]);
            _teams[1].PuzzelsTeam.Add(GameDBFake.puzzelTeams[3]);
        }

        public Team NewTeam(Team t)
        {
            t.Id = _teams.Count + 10;
            _teams.Add(t);

            return t;
        }

        public Team GetTeam(int id)
        {
            return _teams.Where(g => g.Id == id).FirstOrDefault();

        }

        public ICollection<Team> GetTeams()
        {
            return _teams;
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _teams.Where(g => g.Id == newTeam.Id).FirstOrDefault();
            oldTeam = newTeam;
            
        }

        public void SetActivePuzzel(int tId, int pId)
        {
            Team oldTeam = _teams.Where(g => g.Id == tId).FirstOrDefault();
            oldTeam.ActivePuzzel = pId;
        }

        public int GetStartPuzzel(int TeamId)
        {
            throw new NotImplementedException();
        }

        public int GetNewPuzzel(int TeamId)
        {
            throw new NotImplementedException();
        }
    }
}
