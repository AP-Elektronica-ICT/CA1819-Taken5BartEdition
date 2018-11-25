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

            if (!context.Games.Any())
            {
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
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="Viktor").ToList(),
                        Score = 5,
                        TeamNaam = "TEam DJ"
                    },
                    new Team()
                    {
                        DiamantenVerzameld = 1,
                        VerzameldeDiamanten = 2,
                        Puzzellijst = context.Puzzels.ToList(),
                        Spelers = context.Spelers.Where(s=> s.Voornaam=="Joren").ToList(),
                        Score = 15,
                        TeamNaam = "Limberg Parking"
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
                        AantalKeerGeraden =0,
                        JuistGeraden =false
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
                        AantalKeerGeraden = 0,
                        JuistGeraden =true
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
                        AantalKeerGeraden = 0,
                        JuistGeraden = false
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
                        AantalKeerGeraden = 0,
                        JuistGeraden = false
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
                        AantalKeerGeraden = 0,
                        JuistGeraden = false
                    }



            };
                foreach (Quizvraag q in vraag)
                {
                    context.Quizvragen.Add(q);
                }
                context.SaveChanges();
            }
        }
    }
}

