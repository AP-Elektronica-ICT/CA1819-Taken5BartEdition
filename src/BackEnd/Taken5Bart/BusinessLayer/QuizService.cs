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
    public class QuizService : IQuizService
    {
        private IQuizRepository _quizRepo;
        
        public QuizService(GameContext context)
        {
            _quizRepo = new QuizRepository(context);
        }

        public QuizService(IQuizRepository quizrepo)
        {
            _quizRepo = quizrepo;
        }

        public ICollection<Quizvraag> GetQuizvragen()
        {
            return _quizRepo.GetQuizvragen();
        }


        public Quizvraag GetQuizvraag(int index)
        {
            return _quizRepo.GetQuizvraag(index);
        }

        
    }
}
