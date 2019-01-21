using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IVlaeykensScoreService
    {
        ICollection<VlaeykensScore> GetVlaeykensScores();
        void AddNewScore(VlaeykensScore Q);
        ICollection<VlaeykensScore> GetVlaeykensTeamScores(int id);
    }
}
