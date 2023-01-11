using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using API_TEST.Models;
using System.Net.Http;

namespace API_TEST.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Create(Inv_Ins_Class inv_Ins_)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:50016/api/");

            var insertinvoice = hc.PostAsJsonAsync<Inv_Ins_Class>("Values", inv_Ins_);
            insertinvoice.Wait();
            var savedata = insertinvoice.Result;
            if (savedata.IsSuccessStatusCode) {  }
            return View("Create");
        }
    }
}
