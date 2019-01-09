using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Puzzels
{
    public interface IMastermindService
    {
        Mastermind NewGame(Mastermind newM);
        ICollection<Mastermind> GetMasterMinds();
        int[] TryAnswer(int teamId, Array answers);
        bool AllFound(int teamId);
    }
}
