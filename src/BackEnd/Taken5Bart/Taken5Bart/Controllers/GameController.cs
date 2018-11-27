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

        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            return Ok(gameService.GetGames());
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var result = gameService.GetGame(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}