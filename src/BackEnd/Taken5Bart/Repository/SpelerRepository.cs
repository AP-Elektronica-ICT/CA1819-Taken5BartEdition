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
            return _context.Spelers.Include(s=>s.AssignedTeam).SingleOrDefault(g => g.Id == id);
        }

        public IEnumerable<Speler> GetSpelers()
        {
            return _context.Spelers.Include(s => s.AssignedTeam);
        }
    }
}
