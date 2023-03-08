using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PE1.Webshop.Core.Entities;
using PE1.Webshop.Core.Repositories;
using PE1.Webshop.Web.Models;
using PE1.Webshop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PE1.Webshop.Web.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            ViewBag.Title = "Losse Letters";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult WrongId()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
