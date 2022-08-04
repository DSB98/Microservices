using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IEnumerable<CustomerModel> Get()
        {
            CustomerModel customerModel1 = new CustomerModel();
            CustomerModel customerModel2 = new CustomerModel();

            customerModel1.CustomerID = 1;
            customerModel1.CustomerName = "AK";
            customerModel1.CustomerPhone = 1111;

            customerModel2.CustomerID=2;
            customerModel2.CustomerName = "DJ";
            customerModel2.CustomerPhone = 222;

            List<CustomerModel> customerList = new List<CustomerModel>();
            customerList.Add(customerModel1);
            customerList.Add(customerModel2);

            return customerList;



        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
