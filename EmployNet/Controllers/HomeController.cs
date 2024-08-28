using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmployNet.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace EmployNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor to initialize the logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action to display the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action to display the leave request form, accessible only to users with the "User" role
        [Authorize(Roles = "User")]
        public IActionResult LeaveRequestForm()
        {
            return View();
        }

        // Action to display the privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Action to handle errors and display the error view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
