using System.Collections.Generic;
using System.Linq;
using Interface.T5B;
using Microsoft.EntityFrameworkCore;
using Models.T5B;

namespace Repository.T5B
{
    class QuizScoreRepository : IQuizScoreRepository
    {
        public ICollection<QuizScore> GetQuizScores()
        {
            throw new System.NotImplementedException();
        }

        public void PostQuizScore()
        {
            throw new System.NotImplementedException();
        }
    }
}
