using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface;
using Interface.T5B;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.T5B;

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

        
        public IActionResult Get()
        {
            return Ok("Hi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Console.WriteLine(id);
            var game = GetGame(id);
            return game;
        }

        private IActionResult GetGame(int id)
        {
            Game game = gameService.GetGame(id);
            if(game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }
    }
}