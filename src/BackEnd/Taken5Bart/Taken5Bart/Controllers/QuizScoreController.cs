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
    [Route("api/quizscores")]
    [ApiController]
    public class QuizScoreController : Controller
    {
        private IQuizScoreService quizScoreService;
        public QuizScoreController(IQuizScoreService service)
        {
            quizScoreService = service;
        }

        // GET: api/Speler
        [HttpGet]
        public ActionResult<IEnumerable<QuizScore>> Get()
        {
            return Ok(quizScoreService.GetQuizScores());

        }

        [HttpPost]
        public ActionResult postScore([FromBody] QuizScore Q)
        { 
            quizScoreService.AddNewScore(Q);
            return Ok();
        }

   
    }
}