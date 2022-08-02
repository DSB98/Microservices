using Microservises_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Microservises_Assignment1.Controllers
{
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        static List<Country> countryList = new List<Country>()
        {
            new Country{ID=1,Name="India",Capital="Delhi"},
            new Country{ID=2,Name="Japan",Capital="Tokyo"},
            new Country{ID=3,Name="Austria",Capital="Vienna"},
            new Country{ID=4,Name="Canada",Capital="Ottawa"},
        };

        //Fetch all countries

        [HttpGet]
        [Route("AllCountries")]
        public IEnumerable<Country> Get()
        {
            return countryList;
        }

        //Add new record
        public Country Post([FromBody] Country country)
        {
            countryList.Add(country);
            return country;
        }

        //Search Country by Id
        [Route("CountryById/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var country = countryList.Find(x => x.ID == id);
            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            } 
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, country);
            }
        }

        //Delete Country

        [Route("CountryDelete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Country country = countryList.Find(item => item.ID == id);
            if (country != null)
            {
                bool isDeleted = countryList.Remove(country);
                if (isDeleted)
                {
                    return Ok(country);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }

        }

        //Update

        public IEnumerable<Country> Put(int id, [FromBody] Country country)
        {
            countryList[id - 1] = country;
            return countryList;
        }

    }
}
