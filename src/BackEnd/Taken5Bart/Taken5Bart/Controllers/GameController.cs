using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taken5Bart.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private IGameService gameService;

        public GameController(IGameService service)
        {
            gameService = service;
        }


        [HttpGet("{id}")]
        public Game Get(int id)
        {
            Game game = GetGame(id);
            return game;
        }

        private Game GetGame(int id)
        {
            return gameService.GetGame(id);
           
        }
    }
}