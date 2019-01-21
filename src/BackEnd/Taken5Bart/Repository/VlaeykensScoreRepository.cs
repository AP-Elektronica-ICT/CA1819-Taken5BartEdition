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

        public ICollection<VlaeykensScore> GetVlaeykensTeamScores(int id)
        {
            ICollection<VlaeykensScore> vlaeykenscores = _context.VlaeykensScores.ToList();
            List<VlaeykensScore> result = new List<VlaeykensScore>();
            foreach (VlaeykensScore score in vlaeykenscores)
            {
                if (score.TeamID == id)
                {
                    result.Add(score);
                }
            }
            return result;
        }

        public void PostVlaeykensScore(VlaeykensScore Q)
        {
            _context.VlaeykensScores.Add(Q);
            _context.SaveChanges();
        }
    }
}
