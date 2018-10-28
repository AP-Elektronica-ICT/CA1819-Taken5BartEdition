using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository
{
    public class GameRepository:IGameRepository
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
            var game = _context.Games.Include(g => g.Sessie).Include(g => g.MogelijkePuzzels).SingleOrDefault(g => g.Id == id);
            return game;
   
        }
    }

    public interface IGameRepository
    {
        Game GetGame(int id);
        void NewGame(Game g);
    }
}
