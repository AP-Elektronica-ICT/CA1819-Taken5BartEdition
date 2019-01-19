using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Puzzels
{
    public interface IFindTheDifferenceRepository
    {
        FindTheDifference NewGame(FindTheDifference newFTD);
        FindTheDifference GetFindTheDifferenceByTeam(int teamId);
        ICollection<FindTheDifference> GetFindTheDifferences();
        void DifferenceFound(int teamId, int itemId);
    }
}
