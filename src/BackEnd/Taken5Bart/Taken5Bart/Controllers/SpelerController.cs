﻿using System;
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
            if (result == null)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

        
        // GET: api/Team/Speler/id
        [HttpGet("{id}/Team")]
        public ActionResult<IEnumerable<Team>> GetTeamFromSpeler(int id)
        {
            var t = spelerService.GetTeamFromSpeler(id);
            if (t == null)
            {
                return NotFound("-1");
            }
            return Ok(t);

        }
        [HttpGet("{id}/sessie")]
        public ActionResult<IEnumerable<Sessie>> GetSessieFromSpeler(int id)
        {
            var s = spelerService.GetSessieFromSpeler(id);
            if (s == null)
            {
                return NotFound("-1");
            }
            return Ok(s);

        }

        [HttpGet("register/{deviceid}")]

        public ActionResult<Speler> GetOnDeviceId(string deviceid)
        {
            var result = spelerService.GetSpelerOnDeviceID(deviceid);

            if (result == null)
            {
                return NotFound(-1);
            }
            return Ok(result);
        }

      
        // POST: api/Speler
        [HttpPost]
        public ActionResult CreateNewPlayer([FromBody] Speler value)
        {
            spelerService.CreateSpeler(value);

            return Ok();
        }

        [HttpPost("{SpelerId}")]
        public ActionResult PostScore(int SpelerId,[FromBody] QuizScore score)
        {
            spelerService.PostQuizScore(SpelerId,score);

            return Ok();
        }


        // PUT: api/Speler/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Speler value)
        {
            Console.WriteLine(value.Voornaam);
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet("{id}/delete")]
        public ActionResult Delete(int id)
        {
            var result = spelerService.GetSpeler(id);
            if (result == null)
            {
                return NotFound(-1);
            }
            spelerService.DeleteSpeler(id);
            return Ok("speler verwijderd");
        }
    }
}
