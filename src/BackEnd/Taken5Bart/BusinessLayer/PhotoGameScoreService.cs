using Interface.T5B;
using Models.T5B;
using Repository.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.T5B
{
    public class PhotoGameScoreService : IPhotoGameScoreService
    {
        private IPhotoGameScoreRepository _photoGameScoreRepo;

        public PhotoGameScoreService(GameContext context)
        {
            _photoGameScoreRepo = new PhotoGameScoreRepository(context);
        }

        public PhotoGameScoreService(IPhotoGameScoreRepository photoGameScoreRepo)
        {
            _photoGameScoreRepo = photoGameScoreRepo;
        }




        public ICollection<PhotoGameScore> GetPhotoGameScores()
        {
            return _photoGameScoreRepo.GetPhotoGameScores();
        }

        public void AddNewScore(PhotoGameScore Q)
        {
            _photoGameScoreRepo.PostPhotoGameScore(Q);
        }

        public ICollection<PhotoGameScore> GetPhotoTeamScores(int id)
        {
            return _photoGameScoreRepo.GetPhotoTeamScores(id);
        }
    }
}
