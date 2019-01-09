using Interface.T5B;
using Models.T5B;
using Repository.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.T5B
{
    public class VlaeykensScoreService : IVlaeykensScoreService
    {
        private IVlaeykensScoreRepository _vlaeykensScoreRepo;

        public VlaeykensScoreService(GameContext context)
        {
            _vlaeykensScoreRepo = new VlaeykensScoreRepository(context);
        }

        public VlaeykensScoreService(IVlaeykensScoreRepository vlaeykensScoreRepo)
        {
            _vlaeykensScoreRepo = vlaeykensScoreRepo;
        }




        public ICollection<VlaeykensScore> GetVlaeykensScores()
        {
            return _vlaeykensScoreRepo.GetVlaeykensScores();
        }

        public void AddNewScore(VlaeykensScore Q)
        {
            _vlaeykensScoreRepo.PostVlaeykensScore(Q);
        }
    }
}
