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
        public IEnumerable<Team> Get()
        {
            var teams = teamService.GetTeams();
            return teams;
        }

        // GET: api/Team/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return GetTeam(id);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
