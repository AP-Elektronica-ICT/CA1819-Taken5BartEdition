using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISteenScoreService
    {
        ICollection<SteenScore> GetSteenScores();
        void AddNewScore(SteenScore Q);
    }
}
