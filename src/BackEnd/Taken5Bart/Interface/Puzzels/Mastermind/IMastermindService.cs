using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Puzzels
{
    public interface IMastermindService
    {
        Mastermind NewGame(int teamId);
        ICollection<Mastermind> GetMasterMinds();
        int[] TryAnswer(int teamId, Array answers);
    }
}
