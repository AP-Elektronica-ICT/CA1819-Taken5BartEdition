using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IPhotoGameScoreService
    {
        ICollection<PhotoGameScore> GetPhotoGameScores();
        void AddNewScore(PhotoGameScore Q);
    }
}
