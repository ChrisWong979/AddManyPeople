using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AddManyPeople.Models;

namespace AddManyPeople.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var paySalaries = new List<PaySalary>
            {
                new PaySalary { PersonName = "A" },
                new PaySalary { PersonName = "B" },
                new PaySalary { PersonName = "C" },
            };

            return View(paySalaries);
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

        [HttpPost]
        public IActionResult PaySalary(IEnumerable<PaySalary> salaries)
        {
            return RedirectToAction("AllPerson");
        }

        public IActionResult AllPerson()
        {
            return View();
        }
    }
}
