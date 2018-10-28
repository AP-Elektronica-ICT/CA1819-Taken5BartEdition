using Interface;
using Interface.T5B;
using Models;
using Models.T5B;
using Repository;
using Repository.T5B;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.T5B
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

        public Game GetGames()
        {
            throw new NotImplementedException();
        }
    }
}
