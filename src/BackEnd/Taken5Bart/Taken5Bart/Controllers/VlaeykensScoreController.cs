using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.T5B;
using Microsoft.AspNetCore.Mvc;
using Models.T5B;

namespace Taken5Bart.Controllers
{
    [Produces("application/json")]
    [Route("api/vlaeykensscores")]
    [ApiController]
    public class VlaeykensScoreController : Controller
    {
        private IVlaeykensScoreService vlaeykensScoreService;
        public VlaeykensScoreController(IVlaeykensScoreService service)
        {
            vlaeykensScoreService = service;
        }

        // GET: api/steenscores
        [HttpGet]
        public ActionResult<IEnumerable<VlaeykensScore>> Get()
        {
            return Ok(vlaeykensScoreService.GetVlaeykensScores());

        }

        [HttpPost]
        public ActionResult postScore([FromBody] VlaeykensScore Q)
        {
            vlaeykensScoreService.AddNewScore(Q);
            return Ok();
        }
    }
}