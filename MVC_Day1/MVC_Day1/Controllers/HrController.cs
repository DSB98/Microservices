using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day1.Controllers
{
    public class HrController : Controller
    {
        public IActionResult Index()
        {
            List<Department> depList = new List<Department>()
            {
                new Department{ID=1, Name="IT"},
                new Department{ID=2, Name="Account"},
                new Department{ID=3, Name="Maintenance"},

            };

            return View("ListDepartment",depList);
        }
        public ActionResult ListDepartment(List<Department> dlist)
        {
            return View(dlist);
        }

        public ActionResult ListEmployee()
        {
            List<Employee> emplist = new List<Employee>()
            {
                new Employee{ID=1,Name="Deepak",Age=24},
                new Employee{ID=2,Name="Raj",Age=24},
                new Employee{ID=3,Name="Shiv",Age=24},
                new Employee{ID=4,Name="Vikas",Age=24},
                new Employee{ID=5,Name="Sagar",Age=24},
            };
            return View(emplist);
        }

        public ActionResult DisplayEmployee()
        {
            Employee e = new Employee()
            {
                ID = 1,
                Name = "Deepak",
                Age = 24,
            };
            return View(e);
        }
    }
}
