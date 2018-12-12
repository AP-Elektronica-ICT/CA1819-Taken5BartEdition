using Interface;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using web_api_testing.Fakes;

namespace web_api_testing
{
    class PuzzelRepoFake : IPuzzelRepository
    {
        private ICollection<Puzzel> _puzzels;

        public PuzzelRepoFake()
        {
            _puzzels = GameDBFake.puzzels.ToList();
        }
        public Puzzel GetPuzzel(int id)
        {
            return _puzzels.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<Puzzel> GetPuzzels()
        {
            throw new NotImplementedException();
        }
    }
}
