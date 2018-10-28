using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface.T5B;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taken5Bart.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Speler/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Console.WriteLine(GetSpeler(id));
            return GetSpeler(id);
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
