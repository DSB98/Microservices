using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day1.Controllers
{
    public class DataController : Controller
    {
        public ActionResult Index()
        {
            // return View();
            // 
            return RedirectToAction("receiveindex");

        }

        public ActionResult Data_Transfer()
        {
            ViewBag.data1 = "Data1";
            ViewData["data2"] = "Data 2";
            //return View();

            return View("Index"); //cannot pass on values of viewbag/viewdata to 
                                  //other actionmethods/views
        }

        public ActionResult Rules1()
        {
            List<string> rules = new List<string>()
            {
                "Avoid T Shirts", "Carry ID Card","Be On Time", "Committed Work"
            };

            //1. using view bag to transfer
            ViewBag.GetRules = rules;

            //2. using viewdata

            ViewData["FollowRules"] = rules;
            return View();
        }

        //tempdata

        public ActionResult FirstRequest()
        {
            List<string> flowerlist = new List<string>();
            flowerlist.Add("Roses");
            flowerlist.Add("Jasmines");
            flowerlist.Add("Lilies");
            flowerlist.Add("Daisy");

            TempData["flowers"] = flowerlist;
            return RedirectToAction("Index");

        }

        public ActionResult receiveindex()
        {
            //return View();
            TempData.Keep();
            return RedirectToAction("ReceiveTempdata", "HR");
        }

        public ActionResult Thirdrequest()
        {
            return View();
        }

    }
}
