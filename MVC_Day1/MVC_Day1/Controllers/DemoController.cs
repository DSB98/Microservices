using Microsoft.AspNetCore.Mvc;
using MVC_Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day1.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string NormalMethod()
        {
            return "Hello.. This is normal method view!";
        }
        public ContentResult Contents()
        {
            return Content("This is ContentResult method view");
        }
        [NonAction]
        public EmptyResult NoResult()
        {
            int amount = 30000;
            float SI = (amount * 3 * 2);
            return new EmptyResult();
        }
        public ViewResult ViewResultMethod()
        {
            ViewBag.Data = "This is ViewResult method of Demo controller";
            return View();
        }
        public JsonResult EmployeeData()
        {
            Employee e = new Employee();
            e.ID = 1;
            e.Name = "Deepak";
            e.Age = 24;
            return Json(e);
        }

        public RedirectResult RedirectMethod()
        {
            return Redirect("Contents");
        }

        public RedirectResult RedirectToPrivacy()
        {
            return Redirect("/Home/Privacy");
        }
    }
}
