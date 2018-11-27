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
        private readonly ISpelerRepository _spelerRepo;
        private readonly ITeamRepository _teamRepo;
        public SpelerService(GameContext context)
        {
            _spelerRepo = new SpelerRepository(context);
            _teamRepo = new TeamRepository(context);
        }
        public SpelerService(ISpelerRepository spelerRepo, ITeamRepository teamRepo)
        {
            _spelerRepo = spelerRepo;
            _teamRepo = teamRepo;
        }

        public Speler GetSpeler(int id)
        {
            Speler s = _spelerRepo.GetSpeler(id);
            return s;
        }



        public ICollection<Speler> GetSpelers()
        {
            return _spelerRepo.GetSpelers();
        }
       
        

        public Team GetTeamFromSpeler(int spelerId)
        {
            Speler s = _spelerRepo.GetSpeler(spelerId);
            Team team = null;
            if (s != null && s.AssignedTeam != null)
            {
                team = _teamRepo.GetTeam(s.AssignedTeam.Id);
            }
            return team;
        }

        
        public void CreateSpeler(Speler newSpeler)
        {
          
            _spelerRepo.NewSpeler(newSpeler);
        }

      

        public Speler GetSpelerOnDeviceID(string deviceId)
        {
            Speler speler = _spelerRepo.GetSpelerOnDevice(deviceId);

            if (deviceId != null)
                return _spelerRepo.GetSpelerOnDevice(deviceId);


            return null;
        }
    }
}
