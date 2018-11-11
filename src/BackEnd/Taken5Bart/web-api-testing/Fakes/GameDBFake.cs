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
                VerzameldeDiamanten = 0,
                Puzzellijst = puzzels,
                Spelers = new List<Speler>()
                {
                    spelers[0],
                    spelers[1]
                },
                Score = 1,
                TeamNaam = "Antwerp!!!"
            },
            new Team()
            {
                Id = 2,
                DiamantenVerzameld = 0,
                VerzameldeDiamanten = 0,
                Puzzellijst = puzzels,
                Spelers = new List<Speler>()
                {
                    spelers[2],
                    spelers[3]
                },
                Score = 5,
                TeamNaam = "TEam DJ"
            },
            new Team()
            {
                Id = 3,
                DiamantenVerzameld = 1,
                VerzameldeDiamanten = 2,
                Puzzellijst = puzzels,
                Spelers = new List<Speler>()
                {
                    spelers[4]
                },
                Score = 15,
                TeamNaam = "Limberg Parking"
            }
        };

        public static List<Sessie> sessies = new List<Sessie>()
        {
            new Sessie()
            {
                StartTijd = new DateTime(2018,11,11),
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
    }
}
