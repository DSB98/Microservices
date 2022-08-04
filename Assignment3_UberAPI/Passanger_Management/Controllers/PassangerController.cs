using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Passanger_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassangerController : ControllerBase
    {
        static List<Passanger> passangers = new List<Passanger>()
            {
                new Passanger{PassangerID=1,PassangerName="Deepak",PassangerPhone=999999},
                new Passanger{PassangerID=2,PassangerName="AK",PassangerPhone=888888}
            };
        // GET: api/<PassangerController>
        [HttpGet]
        public IEnumerable<Passanger> Get()
        {
            
            return passangers;
        }

        // GET api/<PassangerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PassangerController>
        [HttpPost]
        public Passanger Post([FromBody] Passanger passanger)
        {
            passangers.Add(passanger);
            return passanger;
        }

        // PUT api/<PassangerController>/5
        [HttpPut("{id}")]
        public IEnumerable<Passanger> Put(int id, [FromBody] Passanger passanger)
        {
            passangers[id - 1] = passanger;
            return passangers;
        }

        // DELETE api/<PassangerController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Passanger> Delete(int id)
        {
            passangers.RemoveAt(id - 1);
            return passangers;
        }
    }
}
