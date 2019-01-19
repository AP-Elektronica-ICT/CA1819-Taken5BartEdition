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
        Mastermind GetMasterMind(int id);
        ICollection<Mastermind> GetAllMastermind();
        void AddTry(int id, bool allFound);
    }
}
