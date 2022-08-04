using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Driver_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {

        static List<Driver> drivers = new List<Driver>()
        {
            new Driver{DriverID=1,DriverName="DJ",DriverPhone=99999,LicenseNo="abc123"},
                new Driver{DriverID=2,DriverName="Sk",DriverPhone=88888,LicenseNo="xyz123"}
        };




        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            
            return drivers;
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public Driver Post([FromBody] Driver driver)
        {
            drivers.Add(driver);
            return driver;
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public IEnumerable<Driver> Put(int id, [FromBody] Driver driver)
        {
            drivers[id - 1] = driver;
            return drivers;
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Driver> Delete(int id)
        {
            drivers.RemoveAt(id-1);
            return drivers;
        }
    }
}
