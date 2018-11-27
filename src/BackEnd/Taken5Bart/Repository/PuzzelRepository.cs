using Interface;
using Microsoft.EntityFrameworkCore;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PuzzelRepository : IPuzzelRepository
    {
        GameContext _context;

        public PuzzelRepository(GameContext context)
        {
            _context = context;
        }

        public Puzzel GetPuzzel(int id)
        {
            return _context.Puzzels.Include(p => p.Locatie).SingleOrDefault(p => p.Id == id);
        }

        public ICollection<Puzzel> GetPuzzels()
        {
            var puzzels = _context.Puzzels.Include(p => p.Locatie).ToList<Puzzel>();
            return puzzels;
            // return _context.Puzzels.ToList();
        }
    }
}
