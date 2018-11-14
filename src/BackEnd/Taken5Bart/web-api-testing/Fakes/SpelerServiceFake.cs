using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using web_api_testing.Fakes;

namespace web_api_testing
{
    
    class SpelerServiceFake : ISpelerService
    {
        private List<Speler> _spelers;
        public SpelerServiceFake()
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
            };
        }

        public Speler GetSpeler(int id)
        {
            return _spelers.Where(s=> s.Id == id).FirstOrDefault();
        }

        public ICollection<Speler> GetSpelers()
        {
            return _spelers;
        }

        public Team GetTeamFromSpeler(int spelerId)
        {
            return new Team();
        }
    }
}
