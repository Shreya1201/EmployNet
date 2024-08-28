using Microsoft.AspNetCore.Mvc;

namespace EmployNet.Controllers
{
    public class ContactusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
