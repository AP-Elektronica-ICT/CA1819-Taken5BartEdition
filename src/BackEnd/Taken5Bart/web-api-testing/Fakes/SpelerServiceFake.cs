﻿using Interface.T5B;
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
                    DeviceId = "5"
                },
                new Speler()
                {
                    Id = 6,
                    Achternaam = "mm",
                    Voornaam = "pp",
                    DeviceId = "6"
                }
            };
        }

        public void CreateSpeler(Speler newSpeler)
        {
            newSpeler.Id = _spelers.Count() + 1;
            _spelers.Add(newSpeler);
        }

        public void DeleteSpeler(int id)
        {
            throw new NotImplementedException();
        }

        public Sessie GetSessieFromSpeler(int spelerId)
        {
            throw new NotImplementedException();
        }

        public Speler GetSpeler(int id)
        {
            return _spelers.Where(s=> s.Id == id).FirstOrDefault();
        }

        public Speler GetSpelerOnDeviceID(string deviceId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Speler> GetSpelers()
        {
            return _spelers;
        }

        public Team GetTeamFromSpeler(int spelerId)
        {
            return new Team();
        }

        public void PostQuizScore(int Spelerid, QuizScore Q)
        {
            throw new NotImplementedException();
        }
    }
}
