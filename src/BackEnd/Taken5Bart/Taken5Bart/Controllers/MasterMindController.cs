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
        [HttpGet("{teamId}")]
        public ActionResult<Mastermind> GetbyTeamID(int teamId)
        {
            var mm = mmService.GetMasterMindByTeam(teamId);
            if (mm == null)
            {
                return NotFound(-1);
            }
            return Ok(mm);
        }

        [HttpGet("{teamId}/Allfound")]
        public ActionResult Allfound(int teamId)
        {
            var m = mmService.AllFound(teamId);
            return Ok(m);
        }

        [HttpPost]
        public IActionResult PostNew([FromBody] Mastermind newM)
        {
            var result = mmService.NewGame(newM);
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