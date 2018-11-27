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
    [Route("api/Quiz")]
    public class QuizController : Controller
    {
        private IQuizService quizService;

        public QuizController(IQuizService service)
        {
            quizService = service;
        }



        [HttpGet]
        public IActionResult Get()
        {
            return Ok(quizService.GetQuizvragen());
        }


        [HttpGet("{index}")]
        public ActionResult<IEnumerable<Quizvraag>> Get(int index)
        {
            return Ok(quizService.GetQuizvraag(index));

        }
    }


}
