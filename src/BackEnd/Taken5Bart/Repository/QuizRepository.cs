using System.Collections.Generic;
using System.Linq;
using Interface.T5B;
using Microsoft.EntityFrameworkCore;
using Models.T5B;

namespace Repository.T5B
{
    public class QuizRepository : IQuizRepository
    {
        GameContext _context;

       


        public QuizRepository(GameContext context)
        {
            _context = context;
        }

        public ICollection<Quizvraag> GetQuizvragen()
        {
            return _context.Quizvragen.ToList();
        }


        public Quizvraag GetQuizvraag(int index)
        {
            return _context.Quizvragen.SingleOrDefault(q => q.Vraagnummer == index);
        }

     
    }
}
