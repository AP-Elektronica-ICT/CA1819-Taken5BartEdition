using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IScoreService
    {
        int SetScore(int teamId, string locatienaam, double score);
        Score GetAllScores(int teamId);
        int GetTotalScore(int teamId);
    }
}
