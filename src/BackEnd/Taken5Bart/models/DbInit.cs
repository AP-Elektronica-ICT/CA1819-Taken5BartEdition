using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.T5B
{
    public class DbInit
    {
        
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            if (!context.Games.Any())
            {

                var locatie = new Locatie[]
                {
                    new Locatie()
                    {
                        Naam = "VlaamseKaai",
                        Latitude = 51.209675f,
                        Longitude = 4.3884186f
                    },

                    new Locatie()
                    {
                        Naam = "Stadsfeestzaal",
                        Latitude = 51.2178361f,
                        Longitude = 4.4091902f
                    },

                    new Locatie()
                    {
                        Naam = "Kathedraal",
                        Latitude = 51.2202678f,
                        Longitude = 4.399327f
                    },

                       new Locatie()
                    {
                        Naam = "vlaeykensgang",
                        Latitude = 51.2201932f,
                        Longitude = 4.4003693f
                    },

                    new Locatie()
                    {
                        Naam = "Grote Markt",
                        Latitude = 51.2212442f,
                        Longitude = 4.3980062f
                    },

                    new Locatie()
                    {
                         Naam = "Het steen",
                        Latitude = 51.2227238f,
                        Longitude = 4.395175f
                    },

                    new Locatie()
                    {
                        Naam = "Museum aan de Stroom",
                        Latitude = 51.2227238f,
                        Longitude = 4.395175f
                    },

                    new Locatie()
                    {
                         Naam = "Havenhuis",
                        Latitude = 51.2227238f,
                        Longitude = 4.395175f
                    }

            

                };
                context.Locaties.AddRange(locatie);
              
                context.SaveChanges();
                var puzzels = new Puzzel[]
                {
                    new Puzzel()
                    {
                        Locatie = locatie[0],
                        Diamant = 1,
                        Uitleg = "blablabla"
                    },

                    new Puzzel()
                    {
                        Locatie = locatie[1],
                        Diamant = 1,
                        Uitleg = "puzzel 2"
                    },

                    new Puzzel()
                    {
                        Locatie = locatie[2],
                        Diamant = 1,
                        Uitleg = "puzzel 3"
                    },


                    new Puzzel()
                    {
                        Locatie = locatie[3],
                        Diamant = 1,
                        Uitleg = "puzzel 4"
                    },


                    new Puzzel()
                    {
                        Locatie = locatie[4],
                        Diamant = 1,
                        Uitleg = "puzzel 5"
                    },



                    new Puzzel()
                    {
                        Locatie = locatie[5],
                        Diamant = 1,
                        Uitleg = "puzzel 6"
                    },


                    new Puzzel()
                    {
                        Locatie = locatie[6],
                        Diamant = 1,
                        Uitleg = "puzzel 7"
                    },


                    new Puzzel()
                    {
                        Locatie = locatie[7],
                        Diamant = 1,
                        Uitleg = "puzzel 8"
                    }



                };
                context.Puzzels.AddRange(puzzels);

                context.SaveChanges();
                var puzzelsIDs = context.Puzzels.Select(p => p.Id);
                var spelers = new Speler[]
               {
                    new Speler()
                    {
                        Voornaam = "Jonas",
                        Achternaam = "K",
                        DeviceId = "1"
                    },
                     new Speler()
                    {
                        Voornaam = "sedf",
                        Achternaam = "e"
                    },
                      new Speler()
                    {
                        Voornaam = "Viktor",
                        Achternaam = "S"
                    },
                      new Speler()
                    {
                        Voornaam = "Joren",
                        Achternaam = "J"
                    }

               };
                foreach (Speler s in spelers)
                {
                    context.Spelers.Add(s);
                }
                context.SaveChanges();


                var teams = new Team[]
                {
                    new Team()
                    {
                        DiamantenVerzameld = 0,
                        //Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="sedf").ToList(),
                        TeamPositionId = 1,
                        Score = 1,
                        StartPuzzel = 0,
                        ActivePuzzel = 0,
                        TeamNaam = "Antwerp!!!",
                        
                    },
                    new Team()
                    {
                        DiamantenVerzameld = 0,
                        //Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="Viktor").ToList(),
                        TeamPositionId = 2,
                        Score = 5,
                        StartPuzzel = 0,
                        ActivePuzzel = 0,
                        TeamNaam = "TEam DJ"
                    },
                    new Team()
                    {
                        DiamantenVerzameld = 1,
                        //Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="Joren").ToList(),
                        TeamPositionId = 3,
                        Score = 15,
                        StartPuzzel = 0,
                        ActivePuzzel = 0,
                        TeamNaam = "Limberg Parking",
                    }
                };
                foreach (Team t in teams)
                {
                    context.Teams.Add(t);
                }
                context.SaveChanges();

                foreach (Team t in teams)
                {
                    foreach (Puzzel p in puzzels)
                    {
                        context.Add(new PuzzelTeam { Puzzel = p, Team = t });
                    }
                }
                var sessie = new Sessie[]
          {
                    new Sessie()
                    {
                        Code ="BARTJE",
                        StartTijd = DateTime.Now,
                        Teams = context.Teams.ToList()
                    }
          };
                foreach (Sessie s in sessie)
                {
                    context.Sessies.Add(s);
                }
                context.SaveChanges();

                foreach (Team t in context.Teams)
                {
                    t.AssignedSessie = sessie[0];
                }

                context.SaveChanges();
               
                var game = new Game[]
                {
                    new Game()
                    {
                        Stad = "Antwerpen",
                        Sessie = context.Sessies.ToList(),
                        MogelijkePuzzels = puzzels
                    }
                };
                foreach (Game g in game)
                {
                    context.Games.Add(g);
                }

                var vraag = new Quizvraag[]
                {
                    new Quizvraag()

                    {
                        Vraagnummer = 1,
                        Vraag = "Welke winkel bevind zich niet in de stadsfeestzaal?",
                        Antwoord1 = "Action",
                        Antwoord2 = "Delifrance",
                        Antwoord3 = "Carrefour",
                        Antwoord4 = "Devernois",
                        Antwoord5 = "Dampshop",
                        Antwoord6 = "Urban Outfitters",
                        Correctie = 3,

                    },

                    new Quizvraag()

                    {
                        Vraagnummer = 2,
                        Vraag = "Van welk dier werden er botten aangetroffen in de gewelven van de stadsfeestzaal?",
                        Antwoord1 = "T-rex",
                        Antwoord2 = "Hond",
                        Antwoord3 = "Walvis",
                        Antwoord4 = "Wolven",
                        Antwoord5 = "Paarden",
                        Antwoord6 = "",
                        Correctie = 3,

                    },
                    new Quizvraag()

                    {
                        Vraagnummer = 3,
                        Vraag = "Wat is er in 2000 gebeurd met de stadsfeestzaal?",
                        Antwoord1 = "Er vond een ontvoering plaats",
                        Antwoord2 = "De stadsfeestzaal is volledig uitgebrand",
                        Antwoord3 = "Het dak van de stadsfeestzaal is insgestort",
                        Antwoord4 = "Er zijn rellen uitgebroken door de presidentsverkiezingen in Amerika",
                        Antwoord5 = "George W. Bush bracht een bezoek aan de stadsfeestzaal",
                        Antwoord6 = "",
                        Correctie = 2,

                    },

                    new Quizvraag()

                     {
                        Vraagnummer = 4,
                        Vraag = "Wat is het adres van de stadsfeestzaal?",
                        Antwoord1 = "Meir 78, 2000 Antwerpen",
                        Antwoord2 = "Meir 168, 2000 Antwerpen",
                        Antwoord3 = "Meir 8a, 2000 Antwerpen",
                        Antwoord4 = "Meir 50, 2000 Antwerpen",
                        Antwoord5 = "",
                        Antwoord6 = "",
                        Correctie = 1,

                    },

                    new Quizvraag()
                    {
                        Vraagnummer = 5,
                        Vraag = "In 2008 werd de stadsfeestzaal benoemd tot beste shopping center van …",
                        Antwoord1 = "Europa",
                        Antwoord2 = "België",
                        Antwoord3 = "De Benelux",
                        Antwoord4 = "De Wereld",
                        Antwoord5 = "Vlaanderen",
                        Antwoord6 = "Antwerpen",
                        Correctie = 3,

                    }
                };

                foreach (Quizvraag q in vraag)
                {
                     context.Quizvragen.Add(q);
                }

                var score = new QuizScore[]
                {
                    new QuizScore
                    {
                        DeviceID = "sfsdfsd",
                        AantalVragen = 5,
                        Score = 5
                    },
                      new QuizScore
                    {
                        DeviceID = "sfsdfsd",
                        AantalVragen = 5,
                        Score = 5
                    }

                };
                foreach (QuizScore q in score)
                {
                    context.QuizScores.Add(q);
                }

                
                context.SaveChanges();
            }
        }
    }
}

