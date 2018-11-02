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
    public class SessieController : ControllerBase
    {
        private ISessieService sessieService;

        public SessieController(ISessieService service)
        {
            sessieService = service;
        }

        // GET: api/Sessie
        [HttpGet]
        public TeamsInSesse GetSessieByCode(int id)
        {
            var result = new TeamsInSesse { Data = sessieService.GetTeamsBySessie(id) };
            return result;
        }

        // GET: api/Sessie/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sessie
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Sessie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class TeamsInSesse
    {
        public int count { get { return Data.Count(); } }
        public IEnumerable<Team> Data
        {
            get; set;
        }
    }
}
