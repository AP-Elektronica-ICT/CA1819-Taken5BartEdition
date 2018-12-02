using Interface.T5B;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using web_api_testing.Fakes;

namespace web_api_testing
{
    
    class SessieRepoFake : ISessionRepository
    {
        private List<Sessie> _sessie;
        public SessieRepoFake()
        {
            _sessie = GameDBFake._gameDB.Sessie.ToList();
        }

        public Sessie AddSessie(Sessie sessie)
        {
            sessie.Id = _sessie.Count + 10;
            _sessie.Add(sessie);
            return sessie;
        }

        public Sessie GetSessie(int id)
        {
            return _sessie.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<Sessie> GetSessies()
        {
            return _sessie;
        }

        public ICollection<Team> GetTeamsBySessie(int sessieId)
        {
            Sessie sessie = _sessie.Where(s => s.Id == sessieId).FirstOrDefault();
            return sessie.Teams;
        }
    }
}
