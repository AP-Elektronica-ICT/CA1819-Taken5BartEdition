using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    internal interface IGameRepository
    {
        Game GetGames();
        void NewGame(Game g);
    }
}
