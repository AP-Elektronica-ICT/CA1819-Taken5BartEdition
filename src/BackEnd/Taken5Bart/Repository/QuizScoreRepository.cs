using System.Collections.Generic;
using System.Linq;
using Interface.T5B;
using Microsoft.EntityFrameworkCore;
using Models.T5B;

namespace Repository.T5B
{
    public class QuizScoreRepository : IQuizScoreRepository
    {
        GameContext _context;




        public QuizScoreRepository(GameContext context)
        {
            _context = context;
        }
        public ICollection<QuizScore> GetQuizScores()
        {
            return _context.QuizScores.ToList();
        }

        public void PostQuizScore(QuizScore Q)
        {
             _context.QuizScores.Add(Q);
            _context.SaveChanges();
        }

      
    }
}
