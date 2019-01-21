using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.T5B
{
    public class VlaeykensScoreRepository : IVlaeykensScoreRepository
    {
        GameContext _context;

        public VlaeykensScoreRepository(GameContext context)
        {
            _context = context;
        }
        public ICollection<VlaeykensScore> GetVlaeykensScores()
        {
            return _context.VlaeykensScores.ToList();
        }

        public void PostVlaeykensScore(VlaeykensScore Q)
        {
            _context.VlaeykensScores.Add(Q);
            _context.SaveChanges();
        }
    }
}
