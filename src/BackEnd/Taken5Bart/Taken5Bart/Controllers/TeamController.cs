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
    [Route("api/Team")]
    [Produces("application/json")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private ITeamService teamService;
        public TeamController(ITeamService service)
        {
            teamService = service;
        }

        // GET: api/Team
        [HttpGet]
        public IActionResult Get()
        {
            var teams = teamService.GetTeams();
            return Ok(teams);
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = teamService.GetTeam(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Team/5/GetScorePosition
        [HttpGet("{id}/GetScorePosition")]
        public IActionResult GetScorePos(int id)
        {
            var t = teamService.GetScorePos(id);
            if (t <0)
            {
                return NotFound(-1);
            }
            return Ok(t);
        }

        //put zou correcter zijn, maar unity kent enkel get en post
        // get: api/Team/2/AddSpeler?spelerID=1
        [HttpGet("{id}/AddSpeler")]
        public IActionResult AddSpeler(int id, int spelerID)
        {
            var result = teamService.SpelerJoin(spelerID, id);
            if (result)
            {
                return Ok(1);
            }
            return NotFound(0);
        }



        // POST: api/Team/id?spelerID=5
        [HttpPost("{id}")]
        public IActionResult Post(int id, int spelerID)
        {
            var result = teamService.SpelerJoin(spelerID, id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private IActionResult GetTeam(int id)
        {
            var t = teamService.GetTeam(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);
        }
    }
}
