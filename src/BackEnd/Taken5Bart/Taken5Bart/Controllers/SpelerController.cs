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
            return Ok();
        }

        // GET: api/Speler/5
        [HttpGet("{id}")]
        public ActionResult<Speler> Get(int id)
        {
            Console.WriteLine(GetSpeler(id));
            return Ok(GetSpeler(id));
        }

        // GET: api/Team/Speler/id
        [HttpGet("{id}/Team/")]
        public IActionResult getTeamFromSpeler(int id)
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
        }

        // PUT: api/Speler/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private IActionResult GetSpeler(int id)
        {
            var speler = spelerService.GetSpeler(id);
            if (speler == null)
            {
                return NotFound();
            }
            return Ok(speler);
        }
    }
}
