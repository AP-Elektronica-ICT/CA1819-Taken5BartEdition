using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.T5B;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.T5B;

namespace Taken5Bart.Controllers
{
    [Produces("application/json")]
    [Route("api/steenscores")]
    [ApiController]
    public class SteenScoreController : Controller
    {
        private ISteenScoreService steenScoreService;
        public SteenScoreController(ISteenScoreService service)
        {
            steenScoreService = service;
        }

        // GET: api/steenscores
        [HttpGet]
        public ActionResult<IEnumerable<SteenScore>> Get()
        {
            return Ok(steenScoreService.GetSteenScores());

        }

        [HttpPost]
        public ActionResult postScore([FromBody] SteenScore Q)
        {
            steenScoreService.AddNewScore(Q);
            return Ok();
        }
    }
}