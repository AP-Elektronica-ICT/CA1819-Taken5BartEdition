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
    public class SpelerRepository:ISpelerRepository
    {
        GameContext _context;

        public SpelerRepository(GameContext context)
        {
            _context = context;
        }

        public void NewSpeler(Speler s)
        {
            _context.Spelers.Add(s);
        }

        public Speler GetSpeler(int id)
        {
            var speler = _context.Spelers.Include(s=>s.AssignedTeam).SingleOrDefault(g => g.Id == id);
            return speler;

        }

        public IEnumerable<Speler> GetSpelers()
        {
            throw new NotImplementedException();
        }

        public Team GetTeamFromSpeler(int spelerId)
        {
            var s = _context.Spelers.Include(sp => sp.AssignedTeam).Single(sp => sp.Id == spelerId);
            var team = _context.Teams.Include(t => t.Spelers).Single(t => t.Id == s.AssignedTeam.Id);
            return team;
        }
    }
}
