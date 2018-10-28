using System.Linq;
using Interface.T5B;
using Microsoft.EntityFrameworkCore;
using Models.T5B;

namespace Repository.T5B
{
    public class GameRepository:IGameRepository
    {
        GameContext _context;

        public GameRepository(GameContext context)
        {
            _context = context;
        }

        public Game GetGame(int id)
        {
            var game = _context.Games.Include(g => g.Sessie).Include(g => g.MogelijkePuzzels).SingleOrDefault(g => g.Id == id);
            return game;
   
        }

        public Game GetGame()
        {
            throw new System.NotImplementedException();
        }

        public void NewGame(Game g)
        {
            _context.Games.Add(g);
        }

    }
}
