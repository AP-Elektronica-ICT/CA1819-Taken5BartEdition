using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public IEnumerable<Game> Get(int id)
        {
            Console.WriteLine(id);
            Game game = GetGame(id);
            return new Game[] { game };
        }

        private Game GetGame(int id)
        {
            return gameService.GetGame(id);
           
        }
    }
}