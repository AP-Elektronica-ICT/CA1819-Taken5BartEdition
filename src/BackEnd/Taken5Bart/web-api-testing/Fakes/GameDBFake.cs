using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_api_testing.Fakes
{
    static class GameDBFake
    {
        //dit is een vooropgestelde Database, dit is een bijna 1 op 1 spiegeling van de DBinit file. 
        public static List<Locatie> locaties = new List<Locatie>(){
            new Locatie()
            {
                Latitude = 0.1f,
                Longitude = 0.2f
            },
            new Locatie()
            {
                Latitude = 0.5f,
                Longitude = 0.7f
            } };

        public static List<Puzzel> puzzels = new List<Puzzel>()
        {

            new Puzzel()
            {
                Id = 1,
                Locatie = new Locatie()
                    {
                        Latitude = 0.1f,
                        Longitude = 0.2f
                    },
                Diamant = 1,
                Uitleg = "blablabla"
            },
            new Puzzel()
            {
                Id = 2,
                Locatie = new Locatie()
                {
                    Latitude = 0.5f,
                    Longitude = 0.7f
                },
                Diamant = 1,
                Uitleg = "puzzel 2"
            }

        };

        public static List<Speler> spelers = new List<Speler>()
        {
            new Speler()
            {
                Id = 1,
                Voornaam = "Jonas",
                Achternaam = "K"
            },
                new Speler()
            {
                Id = 2,
                Voornaam = "sedf",
                Achternaam = "e"
            },
            new Speler()
            {
                Id = 3,
                Voornaam = "dd",
                Achternaam = "dddd"
            },
                new Speler()
            {
                Id = 4,
                Voornaam = "Viktor",
                Achternaam = "S"
            },
            new Speler()
            {
                Id = 5,
                Voornaam = "Joren",
                Achternaam = "J"
            }
        };

        public static List<Team> teams = new List<Team>()
        {

            new Team()
            {
                Id = 1,
                DiamantenVerzameld = 0,
                //////Puzzellijst = {1,2 },
                Spelers = new List<Speler>()
                {
                    spelers[0],
                    spelers[1]
                },
                Score = 1,
                TeamNaam = "Antwerp!!!",
                ActivePuzzel = -1
            },
            new Team()
            {
                Id = 2,
                DiamantenVerzameld = 0,
                //////Puzzellijst = {1,2 },
                Spelers = new List<Speler>()
                {
                    spelers[2],
                    spelers[3]
                },
                Score = 5,
                TeamNaam = "TEam DJ",
                ActivePuzzel = 1
            },
            new Team()
            {
                Id = 3,
                DiamantenVerzameld = 1,
                ////Puzzellijst = {1,2 },
                Spelers = new List<Speler>()
                {
                    spelers[4]
                },
                Score = 15,
                TeamNaam = "Limberg Parking",
                ActivePuzzel = -1
            }
        };

        public static List<Sessie> sessies = new List<Sessie>()
        {
            new Sessie()
            {
                Id = 1,
                StartTijd = new DateTime(2018,11,11),
                Code = "AC",
                Teams = new List<Team>()
                {
                    teams[0],
                    teams[1]
                }
            }
        };

        public static Game _gameDB = new Game(){
                Stad = "Antwerpen",
                Sessie = new List<Sessie>()
                {
                    sessies[0]
                },
                MogelijkePuzzels = puzzels
            };

        public static List<PuzzelTeam> puzzelTeams = new List<PuzzelTeam>()
        {
            new PuzzelTeam
            {
                Puzzel = puzzels[0],
                PuzzelId = puzzels[0].Id,
                Team = teams[0],
                TeamId = teams[0].Id
            },
            new PuzzelTeam
            {
                Puzzel = puzzels[1],
                PuzzelId = puzzels[1].Id,
                Team = teams[0],
                TeamId = teams[0].Id
            },
            new PuzzelTeam
            {
                Puzzel = puzzels[0],
                PuzzelId = puzzels[0].Id,
                Team = teams[1],
                TeamId = teams[1].Id
            },
            new PuzzelTeam
            {
                Puzzel = puzzels[1],
                PuzzelId = puzzels[1].Id,
                Team = teams[1],
                TeamId = teams[1].Id
            },
        };

        
    }
}
