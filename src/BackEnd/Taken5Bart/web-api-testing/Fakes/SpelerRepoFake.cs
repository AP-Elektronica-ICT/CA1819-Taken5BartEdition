using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using web_api_testing.Fakes;

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
                    Id = 1,
                    Voornaam = "Jonas",
                    Achternaam = "K",
                    AssignedTeam = new Team()
                {
                    Id = 1,
                    DiamantenVerzameld = 0,
                    //Puzzellijst = null,
                    Score = 1,
                    TeamNaam = "Antwerp!!!"
                },
                },
                    new Speler()
                {
                    Id = 2,
                    Voornaam = "sedf",
                    Achternaam = "e",
                    AssignedTeam = new Team()
                {
                    Id = 1,
                    DiamantenVerzameld = 0,
                    //Puzzellijst = null,
                    Score = 1,
                    TeamNaam = "Antwerp!!!"
                },
                },
                new Speler()
                {
                    Id = 3,
                    Voornaam = "dd",
                    Achternaam = "dddd",
                    AssignedTeam = new Team()
                {
                    Id = 2,
                    DiamantenVerzameld = 0,
                    //Puzzellijst = null,
                    Score = 5,
                    TeamNaam = "TEam DJ"
                },
                },
                    new Speler()
                {
                    Id = 4,
                    Voornaam = "Viktor",
                    Achternaam = "S",
                    AssignedTeam = new Team()
                {
                    Id = 2,
                    DiamantenVerzameld = 0,
                    //Puzzellijst = null,
                    Score = 5,
                    TeamNaam = "TEam DJ"
                },
                },
                new Speler()
                {
                    Id = 5,
                    Voornaam = "Joren",
                    Achternaam = "J",
                    AssignedTeam = new Team()
                {
                    Id = 3,
                    DiamantenVerzameld = 1,
                    //Puzzellijst = null,
                    Score = 15,
                    TeamNaam = "Limberg Parking"
                }
                }
            };
        }
        public Speler GetSpeler(int id)
        {
            return _spelers.Where(s => s.Id == id).FirstOrDefault();
        }

        public Speler GetSpelerOnDevice(string DeviceID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Speler> GetSpelers()
        {
            return _spelers;
        }

        public Speler NewSpeler(Speler s)
        {
            s.Id = _spelers.Count() + 10;
            _spelers.Add(s);
            return s;
        }

        Speler ISpelerRepository.NewSpeler(Speler s)
        {
            throw new NotImplementedException();
        }
    }
}
