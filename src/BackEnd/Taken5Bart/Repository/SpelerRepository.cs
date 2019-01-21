using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Interface.T5B;

namespace Repository.T5B
{
    public class SpelerRepository : ISpelerRepository
    {
        GameContext _context;

        public SpelerRepository(GameContext context)
        {
            _context = context;
        }

        public Speler NewSpeler(Speler s)
        {
            //Speler toevoegen in de databank, Id wordt dan ook toegekend
            _context.Spelers.Add(s);
            _context.SaveChanges();
            return s;
        }

        public Speler GetSpeler(int id)
        {
            return _context.Spelers.Include(s => s.AssignedTeam).Include(s => s.quizScore).SingleOrDefault(g => g.Id == id);
        }

        public Speler GetSpelerOnDevice(string DeviceID)
        {
            return _context.Spelers.SingleOrDefault(g => g.DeviceId == DeviceID);
        }

 
        public ICollection<Speler> GetSpelers()
        {
            return _context.Spelers.Include(s => s.AssignedTeam).ToList();
        }
        public ICollection<Speler> GetSpelersRegisterd()
        {
            return _context.Spelers.ToList();
        }

        public void PostQuizScore(int Spelerid, QuizScore Q)
        {
            Speler speler = _context.Spelers.FirstOrDefault(sp => sp.Id == Spelerid);
            if (Q != null)
            {
                speler.quizScore = Q;
                _context.SaveChanges();
            }
          

        }

        public void DeleteSpeler(int id)
        {
            var speler = _context.Spelers.Find(id);
            _context.Spelers.Remove(speler);
            _context.SaveChanges();
        }
    }
}
