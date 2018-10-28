using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;

namespace BusinessLayer.T5B
{
    class SpelerService : ISpelerService
    {
        private ISpelerRepository gameRepo;
        public SpelerService(GameContext context)
        {
            spelerRepo = new SpelerRepository(context);
        }
        public Speler GetSpeler(int id)
        {
            Speler s = spelerRepo.GetSpeler(id);
            return s;
        }
    }
}
