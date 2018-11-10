using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_api_testing
{
    class SpelerRepoFake : ISpelerRepository
    {
        private List<Speler> _spelers;
        public SpelerRepoFake()
        {
            _spelers = new List<Speler>()
            {
                new Speler()
                {
                    Id = 5,
                    Achternaam = "vi",
                    Voornaam = "jo",
                    DeviceId = 5
                },
                new Speler()
                {
                    Id = 6,
                    Achternaam = "mm",
                    Voornaam = "pp",
                    DeviceId = 6
                }
            }; ;
        }
        public Speler GetSpeler(int id)
        {
            return _spelers.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<Speler> GetSpelers()
        {
            return _spelers;
        }

        public void NewSpeler(Speler s)
        {
            _spelers.Add(s);
        }
    }
}
