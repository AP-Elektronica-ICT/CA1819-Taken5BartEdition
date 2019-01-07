using Interface.Puzzels;
using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class MastermindRepository : IMastermindRepository
    {
        GameContext _context;

        public MastermindRepository(GameContext context)
        {
            _context = context;
        }

        public ICollection<Mastermind> GetAllMasterminds()
        {
            return _context.Masterminds.ToList();
        }

        public Mastermind GetMasterMindByTeam(int teamId)
        {
            return _context.Masterminds.SingleOrDefault(m=>m.AssignedTeamId == teamId);
        }

        public Mastermind NewGame(Mastermind newMM)
        {
            _context.Masterminds.Add(newMM);
            _context.SaveChanges();
            return newMM;
        }
    }
}
