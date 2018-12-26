using Interface;
using Models.T5B;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class PuzzelService : IPuzzelService
    {
        private IPuzzelRepository _puzzelRepo;

        public PuzzelService(GameContext context)
        {
            _puzzelRepo = new PuzzelRepository(context);
        }
        public PuzzelService(IPuzzelRepository puzzelRepo)
        {
            _puzzelRepo = puzzelRepo;
        }

        public Locatie GetLocatie(int id)
        {
            var p = _puzzelRepo.GetPuzzel(id);
            if (p == null)
            {
                return null;
            }
            return _puzzelRepo.GetPuzzel(id).Locatie;
        }

        public Puzzel GetPuzzel(int id)
        {
            return _puzzelRepo.GetPuzzel(id);
        }

        public ICollection<Puzzel> GetPuzzels()
        {
            return _puzzelRepo.GetPuzzels();
        }
    }
}
