using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.Puzzels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Taken5Bart.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterMindController : ControllerBase
    {
        private IMastermindService mmService;

        public MasterMindController(IMastermindService service)
        {
            mmService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Mastermind>> Get()
        {
            return Ok(mmService.GetMasterMinds());
        }

        [HttpPost]
        public IActionResult PostNew([FromBody] int teamID)
        {
            var result = mmService.NewGame(teamID);
            if (result == null)
            {
                return BadRequest(-1);
            }
            return Ok(result);
        }

        [HttpPost("try")]
        public IActionResult PostTry([FromBody] TryAnswer tryAnswer)
        {
            var result = mmService.TryAnswer(tryAnswer.teamID, tryAnswer.answers);
            if (result == null)
            {
                return BadRequest(-1);
            }
            return Ok(result);
        }

    }

    public class TryAnswer
    {
        public int teamID;
        public int[] answers;
    }
}