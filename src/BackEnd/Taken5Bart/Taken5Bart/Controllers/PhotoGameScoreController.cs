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
    [Route("api/photogamescores")]
    [ApiController]
    public class PhotoGameScoreController : Controller
    {
        private IPhotoGameScoreService photoGameScoreService;
        public PhotoGameScoreController(IPhotoGameScoreService service)
        {
            photoGameScoreService = service;
        }

        // GET: api/steenscores
        [HttpGet]
        public ActionResult<IEnumerable<PhotoGameScore>> Get()
        {
            return Ok(photoGameScoreService.GetPhotoGameScores());

        }

        [HttpPost]
        public ActionResult postScore([FromBody] PhotoGameScore Q)
        {
            photoGameScoreService.AddNewScore(Q);
            return Ok();
        }
    }
}