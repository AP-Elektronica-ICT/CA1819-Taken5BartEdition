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
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService scoreService;

        public ScoreController(IScoreService service)
        {
            scoreService = service;
        }

        [HttpGet("{teamid}")]
        public ActionResult getallscores(int teamid)
        {
            return Ok(scoreService.GetAllScores(teamid)); 
        }
        [HttpGet("{teamid}/total")]

        public ActionResult gettotalscores(int teamid)
        {
            return Ok(scoreService.GetTotalScore(teamid));
        }

        [HttpPost("{teamid}/{locatienaam}/{score}")]
        public ActionResult gettotalscores(int teamid, string locatienaam, double score)
        {
            return Ok(scoreService.SetScore(teamid, locatienaam, score));
        }

    }
}
