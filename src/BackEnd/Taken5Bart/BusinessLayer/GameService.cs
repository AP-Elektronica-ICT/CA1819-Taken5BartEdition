using Interface;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    //Hier gebeurt al de magie (controllers zijn de deur), repo en model zijn de deur naar de DB
    public class GameService: IGameService
    {
        private GameRepository gameRepo;
        public GameService(GameContext context)
        {
            gameRepo = new GameRepository(context);
        }

        public Game GetGame(int Id)
        {
            Game game = gameRepo.GetGame(Id);
            return game;
        }
    }
}
