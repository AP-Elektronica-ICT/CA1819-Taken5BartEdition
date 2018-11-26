using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;
namespace BusinessLayer.T5B
{
    public class QuizScoreService : IQuizScoreService
    {

        private IQuizScoreRepository _quizScoreRepo;

        public QuizScoreService(GameContext context)
        {
            _quizScoreRepo = new QuizScoreRepository(context);
        }

        public QuizScoreService(IQuizScoreRepository quizScoreRepo)
        {
            _quizScoreRepo = quizScoreRepo;
        }

      


        public ICollection<QuizScore> GetQuizScores()
        {
            return _quizScoreRepo.GetQuizScores();
        }

        public void PostQuizScore()
        {
            throw new NotImplementedException();
        }
    }
}
