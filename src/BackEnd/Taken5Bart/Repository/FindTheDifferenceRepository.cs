using Interface.FTD;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class FindTheDifferenceRepository : IFindTheDifferenceRepository
    {
        GameContext _context;

        public FindTheDifferenceRepository(GameContext context)
        {
            _context = context;
        }

        public void DifferenceFound(int teamId, int itemId)
        {
            var ftd = _context.FindTheDifferences.Include(f => f.FoundItemsList).Single(f => f.AssignedTeamId == teamId);
            if(ftd != null)
            {
                var ftdList = ftd.FoundItemsList;
                ftdList.Single(t => t.Id == itemId).found = true;
                ftd.FoundItemsList = ftdList;
                _context.SaveChanges();
            }
        }

        public FindTheDifference GetFindTheDifferenceByTeam(int teamId)
        {
            return _context.FindTheDifferences.Include(f => f.FoundItemsList).Where(f => f.AssignedTeamId == teamId).SingleOrDefault();
        }

        public ICollection<FindTheDifference> GetFindTheDifferences()
        {
            return _context.FindTheDifferences.Include(f => f.FoundItemsList).ToList();
        }

        public FindTheDifference NewGame(FindTheDifference newFTD)
        {
            _context.FindTheDifferences.Add(newFTD);
            _context.SaveChanges();
            return newFTD;
        }
    }
}
