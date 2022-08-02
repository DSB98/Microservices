using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        static List<Person> personlist = new List<Person>()
        {
            new Person{ ID=1, Name="Deepak", City="Pune" },
            new Person{ ID=2, Name="Raj", City="Pune" },
            new Person{ ID=3, Name="Shravan", City="Pune" },
            new Person{ ID=4, Name="Shiv", City="Pune" },
            new Person{ ID=5, Name="AK", City="Pune" },
        };

        [HttpGet]
        [Route("persondetails")]
        public IEnumerable<Person> Get()
        {
            return personlist;
        }

        [HttpGet]
        [Route("personlist")]

        public HttpResponseMessage GetPersonList()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK,personlist);
            return response;
        }
        [Route("p/{pid}")]
        public HttpResponseMessage GetP(int pid)
        {
            var person = personlist.Find(x => x.ID == pid);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,pid);
            }
            else{
                return Request.CreateResponse(HttpStatusCode.OK, person);
            }
        }

        //post

        public Person Post([FromBody] Person p)
        {
            personlist.Add(p);
            return p;
        }


        //Put
        public IEnumerable<Person> Put(int id, [FromBody]Person person)
        {
            personlist[id - 1] = person;
            return personlist;
        }

        [HttpGet]
        [Route("Getname/{pid}")]
        public IHttpActionResult GetName(int pid)
        {
            string person = personlist.Where(x => x.ID == pid).SingleOrDefault()?.Name ;

                if (person == null)
            { 
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }
    }
}
