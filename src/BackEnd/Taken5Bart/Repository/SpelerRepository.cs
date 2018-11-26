using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.T5B
{
    public class SpelerRepository:ISpelerRepository
    {
        GameContext _context;

        public SpelerRepository(GameContext context)
        {
            _context = context;
        }

        public void NewSpeler(Speler s)
        {
            _context.Spelers.Add(s);
        }

        public Speler GetSpeler(int id)
        {
            return _context.Spelers.Include(s=>s.AssignedTeam).SingleOrDefault(g => g.Id == id);
        }

<<<<<<< HEAD
=======
        public Speler GetSpelerOnDevice(string DeviceID)
        {
            return _context.Spelers.SingleOrDefault(g => g.DeviceId == DeviceID);
        }




        //nieuwe speler aanmaken:
        public void PostSpeler(Speler speler)
        {
            //Speler toevoegen in de databank, Id wordt dan ook toegekend
            _context.Spelers.Add(speler);
            _context.SaveChanges();
        }

>>>>>>> ed617f3... Start checkondeviceid
        public ICollection<Speler> GetSpelers()
        {
            return _context.Spelers.Include(s => s.AssignedTeam).ToList();
        }




        public string CheckRegisterdPlayer(Speler Speler)
        {
            var speler = _context.Spelers.Where(i => i.DeviceId == Speler.DeviceId);

            if (speler != null)
                return Speler.DeviceId;

            return null;      
        }

       
    }
}
