using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi.Models;

namespace WebApi.Controllers
{
    public class DemoController : ApiController
    {
        static List<string> mystrings = new List<string> { "value0", "value1", "value2", "value3", "value4" };

        //GET: api/Demo
        public IEnumerable<string> Get()
        {
            return mystrings;
        }

        //GET: api/Demo/2
        public string Get(int id)
        {
            return mystrings[id];
        }

        //POST: 
        //public IEnumerable<string> Post([FromUri] string val)
        //{
        //    mystrings.Add(val);
        //    return mystrings;
        //}

        //public IEnumerable<string> Post([FromBody] string val)
        //{
        //    mystrings.Add(val);
        //    return mystrings;
        //}


        //public IEnumerable<string> Post([FromBody] SampleModel m)
        //{
        //    mystrings.Add(m.Name);
        //    return mystrings;
        //}

        public IEnumerable<string> Post([FromUri] SampleModel m)
        {
            mystrings.Add(m.Name);
            return mystrings;
        }

        //PUT
        public IEnumerable<string> Put(int id, [FromUri]string val)
        {
            mystrings[id - 1] = val;
            return mystrings;
        }

        public IEnumerable<string> Delete(int id)
        {
            mystrings.RemoveAt(id);
            return mystrings;
        }
    }
}
