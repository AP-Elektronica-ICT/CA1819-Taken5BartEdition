using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IPhotoGameScoreRepository
    {
        ICollection<PhotoGameScore> GetPhotoGameScores();
        void PostPhotoGameScore(PhotoGameScore Q);
        ICollection<PhotoGameScore> GetPhotoTeamScores(int id);
    }
}
