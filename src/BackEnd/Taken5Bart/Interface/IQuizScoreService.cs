using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    interface IQuizScoreService
    {
        ICollection<QuizScore> GetQuizScores();
        void PostQuizScore();
    }
}
