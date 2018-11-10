using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Models.T5B;
using Interface.T5B;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace web_api_testing
{
    public class TeamRepositoryFake: ITeamRepository
    {
        private List<Team> _teams;

        public TeamRepositoryFake()
        {
            _teams = new List<Team>()
            {
                new Team()
                {
                    Id = 1,
                    DiamantenVerzameld = 0,
                    Score = 15,
                    VerzameldeDiamanten = 1,
                    TeamNaam = "gokai",
                    Spelers = new List<Speler>()
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
                    }
                },
                new Team()
                {
                    Id = 2,
                    DiamantenVerzameld = 1,
                    Score = 111,
                    VerzameldeDiamanten = 2,
                    TeamNaam = "Gunzen",
                    Spelers = new List<Speler>()
                    {
                        new Speler()
                        {
                            Id = 1,
                            Achternaam = "dd",
                            Voornaam = "FNAF",
                            DeviceId = 3
                        },
                        new Speler()
                        {
                            Id = 2,
                            Achternaam = "kdo",
                            Voornaam = "2Ce,t",
                            DeviceId = 2
                        }
                    }
                }
            };
        }

        public void NewTeam(Team t)
        {
            _teams.Add(t);
        }

        public Team GetTeam(int id)
        {
            return _teams.Where(g => g.Id == id).FirstOrDefault();

        }

        public ICollection<Team> GetTeams()
        {
            return _teams;
        }

        public void UpdateTeam(Team newTeam)
        {
            Team oldTeam = _teams.Where(g => g.Id == newTeam.Id).FirstOrDefault();
            oldTeam = newTeam;
            
        }
    }
}
