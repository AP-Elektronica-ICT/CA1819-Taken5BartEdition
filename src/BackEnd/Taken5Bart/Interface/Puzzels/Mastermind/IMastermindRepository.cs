using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Interface.Puzzels
{
    public interface IMastermindRepository
    {
        Mastermind NewGame(Mastermind newMM);
        Mastermind GetMasterMindByTeam(int teamId);
        ICollection<Mastermind> GetAllMasterminds();
    }
}
