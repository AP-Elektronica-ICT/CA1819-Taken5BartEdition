using Models;
using Models.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface.T5B
{
    public interface IGameRepository
    {
        Game GetGame(int id);
        IEnumerable<Game> GetGames();
        void NewGame(Game g);
    }
}
