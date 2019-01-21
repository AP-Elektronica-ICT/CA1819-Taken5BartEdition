using Interface.T5B;
using Models.T5B;
using Repository.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.T5B
{
    public class SteenScoreService : ISteenScoreService
    {
        private ISteenScoreRepository _steenScoreRepo;

        public SteenScoreService(GameContext context)
        {
            _steenScoreRepo = new SteenScoreRepository(context);
        }

        public SteenScoreService(ISteenScoreRepository steenScoreRepo)
        {
            _steenScoreRepo = steenScoreRepo;
        }




        public ICollection<SteenScore> GetSteenScores()
        {
            return _steenScoreRepo.GetSteenScores();
        }

        public void AddNewScore(SteenScore Q)
        {
            _steenScoreRepo.PostSteenScore(Q);
        }

        public ICollection<SteenScore> GetSteenTeamScores(int id)
        {
            return _steenScoreRepo.GetSteenTeamScores(id);
        }
    }
}
