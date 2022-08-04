using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IEnumerable<ProductModel> Get()
        {
            ProductModel productModel1 = new ProductModel();
            ProductModel productModel2 = new ProductModel();
            productModel1.ProductId = 1;
            productModel1.ProductName = "LAptop";
            productModel1.Description = "Dell";
            productModel1.Price = 56000;

            productModel2.ProductId = 2;
            productModel2.ProductName = "Mobile";
            productModel2.Description = "Oneplus";
            productModel2.Price = 40000;

            List<ProductModel> productList = new List<ProductModel>();
            productList.Add(productModel1);
            productList.Add(productModel2);
            return productList;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
