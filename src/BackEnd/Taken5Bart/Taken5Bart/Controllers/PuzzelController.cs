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
    [Route("api/puzzel")]
    public class PuzzelController : Controller
    {
        private IPuzzelService puzzelService;

        public PuzzelController(IPuzzelService service)
        {
            puzzelService = service;
        }

        // GET api/puzzel
        [HttpGet]
        public ActionResult<IEnumerable <Puzzel>> Get()
        {
            return Ok(puzzelService.GetPuzzels());
        }

        // GET api/puzzel/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable <Puzzel>> Get(int id)
        {
            if (puzzelService.GetPuzzel(id) == null)
            {
                return NotFound(-1);
            }
            return Ok(puzzelService.GetPuzzel(id));
        }

        // GET api/puzzel/5/location
        [HttpGet("{id}/location")]
        public ActionResult<IEnumerable<Puzzel>> GetLocation(int id)
        {
            if (puzzelService.GetLocatie(id) == null)
            {
                return NotFound(-1);
            }
            return Ok(puzzelService.GetLocatie(id));
        }
    }
}
