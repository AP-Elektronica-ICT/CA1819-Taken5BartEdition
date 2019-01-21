using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.T5B
{
    public class PhotoGameScoreRepository : IPhotoGameScoreRepository
    {
        GameContext _context;

        public PhotoGameScoreRepository(GameContext context)
        {
            _context = context;
        }
        public ICollection<PhotoGameScore> GetPhotoGameScores()
        {
            return _context.PhotoGameScores.ToList();
        }

        public ICollection<PhotoGameScore> GetPhotoTeamScores(int id)
        {
            ICollection<PhotoGameScore> photoscores = _context.PhotoGameScores.ToList();
            List<PhotoGameScore> result = new List<PhotoGameScore>();
            foreach (PhotoGameScore score in photoscores)
            {
                if (score.TeamID == id)
                {
                    result.Add(score);
                }
            }
            return result;
        }

        public void PostPhotoGameScore(PhotoGameScore Q)
        {
            _context.PhotoGameScores.Add(Q);
            _context.SaveChanges();
        }
    }
}
