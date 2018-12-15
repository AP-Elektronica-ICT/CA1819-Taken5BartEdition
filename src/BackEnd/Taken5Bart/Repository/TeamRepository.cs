using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.T5B
{
    public class TeamRepository: ITeamRepository
    {
        GameContext _context;

        public TeamRepository(GameContext context)
        {
            _context = context;
        }

        public Team NewTeam(Team t)
        {
            _context.Teams.Add(t);
            _context.SaveChanges();
            return t;
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Include(t=>t.Spelers).Include(t => t.AssignedSessie).Include(t => t.PuzzelsTeam).ThenInclude(t=>t.Puzzel).SingleOrDefault(g => g.Id == id);

        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(t => t.Spelers).Include(t => t.PuzzelsTeam).ThenInclude(t => t.Puzzel).ToList();
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == newTeam.Id);
            oldTeam = newTeam;
            _context.SaveChanges();
        }

        public void SetActivePuzzel(int tId, int pId)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == tId);
            oldTeam.ActivePuzzel = pId;
            _context.SaveChanges();
        }

        public int GetStartPuzzel(int TeamId)
        {
            Team team = _context.Teams.Include(t => t.AssignedSessie).Single(t => t.Id == TeamId);
            int index = 0;
            System.Diagnostics.Debug.WriteLine(index);

            if (team.TeamPositionId == 0)
            {
                team.StartPuzzel = 1;
            }
            else
            { 
                team.StartPuzzel = team.TeamPositionId + 2;
            }
            team.ActivePuzzel = team.StartPuzzel;
            _context.SaveChanges();
            return team.StartPuzzel;
        }

        public int GetNewPuzzel(int TeamId)
        {
            Team team = _context.Teams.Single(t => t.Id == TeamId);

            team.ActivePuzzel++;

            if(team.ActivePuzzel == team.StartPuzzel)
            {
                team.ActivePuzzel = 8;
            }
            else if ( team.ActivePuzzel == 8 && team.StartPuzzel != 1)
            {
                team.ActivePuzzel = 1;
            }
            _context.SaveChanges();

            return team.ActivePuzzel;
        }
    }
}
