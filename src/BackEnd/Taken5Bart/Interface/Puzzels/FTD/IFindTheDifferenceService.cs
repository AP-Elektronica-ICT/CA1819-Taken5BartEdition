using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.Puzzels
{
    public interface IFindTheDifferenceService
    {
        FindTheDifference NewGame(int teamId, int itemCount);
        ICollection<FindTheDifference> GetFindTheDifferences();
        void DifferenceFound(int teamId, int itemId);
        int ItemsFoundCount(int teamId);
    }
}
