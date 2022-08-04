using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Core_EF.Models;

namespace WebApp_Core_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private const string employeecache = "employeelist";
        private readonly IEmployeeRepository _datarepository;
        private IMemoryCache _cache;
        private ILogger<EmployeeController> _logger;

        //constructor

        public EmployeeController(IEmployeeRepository erepo, IMemoryCache cache, ILogger<EmployeeController> logger)
        {
            _datarepository = erepo;
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            _logger.Log(LogLevel.Information,"Trying to fetch the list of employee from chache");
            if(_cache.TryGetValue(employeecache,out IEnumerable<Employee> employees))
            {
                _logger.Log(LogLevel.Information, "Employees list found in the cache");

            }
            else
            {
                _logger.Log(LogLevel.Information, "Employee list is not found in the cache, hense fetching from the database");
                employees = _datarepository.GetAllEmployees();
                var cacheentryoptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3000))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);

                _cache.Set(employeecache, cacheentryoptions);

                
            }
            return Ok(employees);

        }
    }
}
