using Interface.FTD;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class FindTheDifferenceService : IFindTheDifferenceService
    {
        private IFindTheDifferenceRepository _ftdRepo;
        public FindTheDifferenceService(GameContext context)
        {
            _ftdRepo = new FindTheDifferenceRepository(context);
        }
        public int ItemsFoundCount(int teamId)
        {
            var ftd = _ftdRepo.GetFindTheDifferenceByTeam(teamId);
            if(ftd == null)
            {
                return -1;
            }
            var result = ftd.FoundItemsList.Count - ftd.ItemsFoundCount;
            return result;
        }

        public void DifferenceFound(int teamId, int itemId)
        {
            _ftdRepo.DifferenceFound(teamId, itemId);
        }

        public ICollection<FindTheDifference> GetFindTheDifferences()
        {
            return _ftdRepo.GetFindTheDifferences();
        }

        public FindTheDifference NewGame(int teamId, int itemCount)
        {
            if(_ftdRepo.GetFindTheDifferenceByTeam(teamId) == null)
            {
                var ftd = new FindTheDifference()
                {
                    AssignedTeamId = teamId,
                    FoundItemsList = new List<FindTheDifferenceItem>()
                };
                for (int i = 0; i < itemCount; i++)
                {
                    ftd.FoundItemsList.Add(new FindTheDifferenceItem() { found = false });
                }
                return _ftdRepo.NewGame(ftd);
            }
            return null;
        }
    }
}
