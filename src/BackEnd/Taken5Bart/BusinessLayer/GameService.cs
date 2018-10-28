using Interface;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    //Hier gebeurt al de magie (controllers zijn de deur), repo en model zijn de deur naar de DB
    //Elke nieuwe service moet ook gelinkt worden aan zijn interface in startup.cs onder ConfigureServices(..){}
    public class GameService:IGameService
    {
        private IGameRepository gameRepo;
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
