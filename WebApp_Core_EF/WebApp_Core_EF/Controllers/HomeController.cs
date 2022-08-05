using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Core_EF.Models;
using System.Data;
using System.Web.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using BindAttribute = System.Web.Mvc.BindAttribute;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using System.Net;

namespace WebApp_Core_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository emprepo;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository erep)
        {
            _logger = logger;
            emprepo = erep;
        }

       // [ActionName("AllEmp")]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AllEmp()
        {
            var model = emprepo.GetAllEmployees();
            return View(model);
        }

        public IActionResult AddEmp(Employee employee)
        {
            var model = emprepo.AddEmployee(employee);
            return View(model);
        }
        public IActionResult Create(Employee employee)
        {
            var model = emprepo.AddEmployee(employee);
           // return RedirectToAction("Index");
           return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Eit,Name,Gender,Salary,Address")] Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        emprepo.AddEmployee(employee);

        //        return RedirectToAction("Index");
        //    }

        //    return View(employee);
        //}

        public ActionResult Edit(Employee emp)
        {
            var model = emprepo.UpdateEmployee(emp);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = emprepo.DeleteEmployee(id);
            return View(model);
        }




    }
}
