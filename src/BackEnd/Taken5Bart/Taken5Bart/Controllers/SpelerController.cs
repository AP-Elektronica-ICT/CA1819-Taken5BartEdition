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
    [Produces("application/json")]
    [Route("api/Speler")]
    [ApiController]
    public class SpelerController : ControllerBase
    {
        private ISpelerService spelerService;
        public SpelerController(ISpelerService service)
        {
            spelerService = service;
        }

        // GET: api/Speler
        [HttpGet]
        public ActionResult<IEnumerable<Speler>> Get()
        {
            return Ok(spelerService.GetSpelers());
        }

        // GET: api/Speler/5
        [HttpGet("{id}")]
        public ActionResult<Speler> Get(int id)
        {
            var result = spelerService.GetSpeler(id);
            if(result == null)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

        // GET: api/Team/Speler/id
        [HttpGet("{id}/Team/")]
        public ActionResult<IEnumerable<Team>> GetTeamFromSpeler(int id)
        {
            var t = spelerService.GetTeamFromSpeler(id);
            if (t == null)
            {
                return NotFound();
            }
            return Ok(t);

        }

        // POST: api/Speler
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
        }

        // PUT: api/Speler/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Speler value)
        {
            Console.WriteLine(value.Voornaam);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
