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
    [Route("api/FTD")]
    public class FindTheDifferenceController : ControllerBase
    {
        private IFindTheDifferenceService ftdService;

        public FindTheDifferenceController(IFindTheDifferenceService service)
        {
            ftdService = service;
        }

        // GET api/puzzel
        [HttpGet]
        public ActionResult<IEnumerable<FindTheDifference>> Get()
        {
            return Ok(ftdService.GetFindTheDifferences());
        }

        [HttpGet("{teamId}")]
        public ActionResult<bool> GetByTeamID(int teamId)
        {
            var ftd = ftdService.ItemsFoundCount(teamId);
            if (ftd == -1)
            {
                return NotFound(-1);
            }
            return Ok(ftd);
        }

        [HttpGet("{teamId}/found")]
        public ActionResult ItemFound(int teamId, int itemId)
        {
            ftdService.DifferenceFound(teamId, itemId);
            return Ok();
        }

        // POST: api/Sessie
        [HttpPost]
        public IActionResult Post([FromBody] newFTD value)
        {
            var result = ftdService.NewGame(value.teamID, value.itemCount);
            if (result == null)
            {
                return BadRequest(-1);
            }
            return Ok(result);
        }
    }

    public class newFTD
    {
        public int teamID;
        public int itemCount;
    }
}