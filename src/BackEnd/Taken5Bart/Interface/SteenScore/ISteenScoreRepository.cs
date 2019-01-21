using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface ISteenScoreRepository
    {
        ICollection<SteenScore> GetSteenScores();
        void PostSteenScore(SteenScore Q);
        ICollection<SteenScore> GetSteenTeamScores(int id);
    }
}
