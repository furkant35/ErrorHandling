using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UdemyErrorHandling.Filter;
using UdemyErrorHandling.Models;

namespace UdemyErrorHandling.Controllers
{

    //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]
    public class HomeController : Controller
    {
        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata1")]
        public IActionResult Index()
        {
            int d1 = 5;
            int d2 = 0;
            int value = d1 / d2;
            return View(value);
        }

        //[CustomHandleExceptionFilterAttribute(ErrorPage = "Hata2")]
        public IActionResult Privacy()
        {
            throw new FileNotFoundException("Böyle bir sayfa yok");
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.path = exception.Path;
            ViewBag.message = exception.Error.Message;
            return View();
        }
        public IActionResult Hata1()
        {
            return View();
        }
        public IActionResult Hata2()
        {
            return View();
        }
    }
}
