using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Repository
{
    public class GameRepository
    {
        GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public void NewGame(Game g)
        {
            _context.Games.Add(g);
        }

        public Game GetGame(int id)
        {
            Game game = _context.Games.Where(g => g.Id == id).Single();
            if (game != null)
                return game;
            else
                return null;
        }
    }
}
