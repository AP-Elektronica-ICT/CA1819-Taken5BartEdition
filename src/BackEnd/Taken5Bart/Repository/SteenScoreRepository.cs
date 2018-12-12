using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.T5B
{
    public class SteenScoreRepository : ISteenScoreRepository
    {
        GameContext _context;




        public SteenScoreRepository(GameContext context)
        {
            _context = context;
        }
        public ICollection<SteenScore> GetSteenScores()
        {
            return _context.SteenScores.ToList();
        }

        public void PostSteenScore(SteenScore Q)
        {
            _context.SteenScores.Add(Q);
            _context.SaveChanges();
        }
    }
}
