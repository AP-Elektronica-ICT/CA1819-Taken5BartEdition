using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IVlaeykensScoreRepository
    {
        ICollection<VlaeykensScore> GetVlaeykensScores();
        void PostVlaeykensScore(VlaeykensScore Q);
        ICollection<VlaeykensScore> GetVlaeykensTeamScores(int id);
    }
}
