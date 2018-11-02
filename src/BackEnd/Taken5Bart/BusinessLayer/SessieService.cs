using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;

namespace BusinessLayer.T5B
{
    public class SessieService : ISessieService
    {
        private ISessionRepository sessieRepo;

        public SessieService(GameContext context)
        {
            sessieRepo = new SessieRepository(context);
        }
        public Sessie GetSessie(int id)
        {
            Sessie s = sessieRepo.GetSessie(id);
            return s;
        }

        public IEnumerable<Sessie> GetSessies()
        {
            IEnumerable<Sessie> s = sessieRepo.GetSessies();
            return s;
        }

        public IEnumerable<Team> GetTeamsBySessie(int sessieId)
        {
            var t = sessieRepo.GetTeams(sessieId);
            return t;
        }
    }
}
