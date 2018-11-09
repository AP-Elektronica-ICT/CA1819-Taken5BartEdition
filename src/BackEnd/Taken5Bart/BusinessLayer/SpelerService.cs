using System;
using System.Collections.Generic;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;

namespace BusinessLayer.T5B
{
    public class SpelerService : ISpelerService
    {
        private readonly SpelerRepository spelerRepo;
        private readonly TeamRepository teamRepo;
        public SpelerService(GameContext context)
        {
            spelerRepo = new SpelerRepository(context);
            teamRepo = new TeamRepository(context);
        }

        public Speler GetSpeler(int id)
        {
            Speler s = spelerRepo.GetSpeler(id);
            return s;
        }

        public IEnumerable<Speler> GetSpelers()
        {
            return spelerRepo.GetSpelers();
        }

        public Team GetTeamFromSpeler(int spelerId)
        {
            Speler s = spelerRepo.GetSpeler(spelerId);
            Team team = teamRepo.GetTeam(s.AssignedTeam.Id);
            return team;
        }
    }
}
