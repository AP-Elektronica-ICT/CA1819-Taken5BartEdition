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
            context.Database.EnsureCreated();

            if (context.Games.Count() < 5) { 
                var locatie = new Locatie[]
                {
                    new Locatie()
                    {
                        Latitude = 0.1f,
                        Longitude = 0.2f
                    },
                     new Locatie()
                    {
                        Latitude = 0.5f,
                        Longitude = 0.7f
                    }
                };
                foreach (Locatie l in locatie)
                {
                    context.Locaties.Add(l);
                }
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
                    }
                };
                foreach (Puzzel p in puzzels)
                {
                    context.Puzzels.Add(p);
                }
                context.SaveChanges();
                var spelers = new Speler[]
               {
                    new Speler()
                    {
                        Voornaam = "Jonas",
                        Achternaam = "K"
                    },
                     new Speler()
                    {
                        Voornaam = "sedf",
                        Achternaam = "e"
                    },
                      new Speler()
                    {
                        Voornaam = "eeeeee",
                        Achternaam = "dddd"
                    },
                      new Speler()
                    {
                        Voornaam = "eeeeee",
                        Achternaam = "dddd"
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
                        VerzameldeDiamanten = 0,
                        Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="sedf").ToList(),
                        Score = 1,
                        TeamNaam = "Antwerp!!!"
                    },
                    new Team()
                    {
                        DiamantenVerzameld = 0,
                        VerzameldeDiamanten = 0,
                        Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="eeeeee").ToList(),
                        Score = 5,
                        TeamNaam = "Antwerp!!!"
                    },
                    new Team()
                    {
                        DiamantenVerzameld = 1,
                        VerzameldeDiamanten = 2,
                        Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="Jonas").ToList(),
                        Score = 15,
                        TeamNaam = "Antwerp!!!"
                    }
                };
                foreach (Team t in teams)
                {
                    context.Teams.Add(t);
                }
     
                context.SaveChanges();
                var sessie = new Sessie[]
                {
                    new Sessie()
                    {
                        StartTijd = DateTime.Now,
                        Teams = context.Teams.ToList()
                    }
                };
                foreach (Sessie s in sessie)
                {
                    context.Sessies.Add(s);
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

                context.SaveChanges();
            }
        }
    }
}
