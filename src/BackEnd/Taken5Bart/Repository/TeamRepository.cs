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

        public void NewTeam(Team t)
        {
            _context.Teams.Add(t);
        }

        public Team GetTeam(int id)
        {
            var team = _context.Teams.Include(t=>t.Spelers).Include(t=>t.Puzzellijst).Include(t => t.AssignedSessie).SingleOrDefault(g => g.Id == id);
            return team;

        }

        public IEnumerable<Team> GetTeams()
        {
            var team = _context.Teams.Include(t => t.Spelers).Include(t => t.Puzzellijst);
            return team;
        }

        public bool SpelerJoin(int spelerId, int teamId)
        {
            Speler speler = _context.Spelers.Find(spelerId);
            var team = _context.Teams.Include(t=>t.Spelers).Single(t=>t.Id==teamId);
            var teamSpeler = team.Spelers;
            if(speler == null || team == null)
            {
                return false;
            }
            teamSpeler.Add(speler);
            team.Spelers = teamSpeler;
            _context.SaveChanges();
            return true;
        }
    }
}
