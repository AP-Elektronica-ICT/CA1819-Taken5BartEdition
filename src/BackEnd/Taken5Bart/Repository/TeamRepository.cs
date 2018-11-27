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
            _context.SaveChanges();
        }

        public Team GetTeam(int id)
        {
            return _context.Teams.Include(t=>t.Spelers).Include(t=>t.Puzzellijst).Include(t => t.AssignedSessie).SingleOrDefault(g => g.Id == id);

        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.Include(t => t.Spelers).Include(t => t.Puzzellijst).ToList();
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _context.Teams.Single(t => t.Id == newTeam.Id);
            oldTeam = newTeam;
            _context.SaveChanges();
        }

        public Team NewTeamT(Team t)
        {
            _context.Teams.Add(t);
            _context.SaveChanges();
            return t;
        }
    }
}
