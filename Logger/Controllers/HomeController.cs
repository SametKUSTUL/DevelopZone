using Logger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        public HomeController(ILogger<HomeController> logger, ILoggerFactory loggerFactory = null)
        {
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        public IActionResult Index()
        {
            var _logger=_loggerFactory.CreateLogger("Home Sınıfı");

            _logger.LogInformation("Index sayfasına gelindi");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy sayfasına gelindi");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Error sayfasına gelindi");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
