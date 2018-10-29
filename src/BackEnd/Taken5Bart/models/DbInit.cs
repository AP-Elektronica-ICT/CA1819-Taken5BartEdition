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
                    }
                };
                foreach (Locatie l in locatie)
                {
                    context.Locaties.Add(l);
                }

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
                        Locatie = locatie[0],
                        Diamant = 1,
                        Uitleg = "puzzel 2"
                    }
                };
                foreach (Puzzel p in puzzels)
                {
                    context.Puzzels.Add(p);
                }

                var spelers = new Speler[]
               {
                    new Speler()
                    {
                        Voornaam = "Jonas",
                        Achternaam = "K"
                    }
               };
                foreach (Speler s in spelers)
                {
                    context.Spelers.Add(s);
                }

                var teams = new Team[]
                {
                    new Team()
                    {
                        DiamantenVerzameld = 0,
                        VerzameldeDiamanten = 0,
                        Puzzellijst = puzzels,
                        Spelers = spelers,
                        Score = 1,
                        TeamNaam = "Antwerp!!!"
                    }
                };
                foreach (Team t in teams)
                {
                    context.Teams.Add(t);
                }

                var sessie = new Sessie[]
                {
                    new Sessie()
                    {
                        StartTijd = DateTime.Now,
                        Teams = teams
                    }
                };
                foreach (Sessie s in sessie)
                {
                    context.Sessies.Add(s);
                }

                var game = new Game[]
                {
                    new Game()
                    {
                        Stad = "Antwerpen",
                        Sessie = sessie,
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
