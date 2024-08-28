using EmployNet.Data;
using EmployNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EmployNet.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display form to create feedback
        public IActionResult Create()
        {
            return View();
        }

        // Handle form submission to create feedback
        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                // Add feedback to the database
                _context.Feedbacks.Add(feedback);
                _context.SaveChanges();

                // Show a thank you message
                TempData["FeedbackMessage"] = "Thank you for your feedback!";

                // Redirect to the home page
                return RedirectToAction("Index", "Home");
            }

            // If model state is invalid, return the same view with the feedback data
            return View(feedback);
        }

        // Display feedback submissions to the admin
        [HttpGet]
        public IActionResult List()
        {
            var feedbackList = _context.Feedbacks.ToList();
            return View(feedbackList);
        }
        public IActionResult ExportToCsv()
        {
            var feedbacks = _context.Feedbacks.ToList();

            var sb = new StringBuilder();
            sb.AppendLine("Name,Email,Subject,Rating,Message,Date Submitted");

            foreach (var feedback in feedbacks)
            {
                sb.AppendLine($"{feedback.Name},{feedback.Email},{feedback.Subject},{feedback.Rating},{feedback.Message},{feedback.SubmittedAt}");
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var output = new MemoryStream(bytes);
            return File(output, "text/csv", "feedbacks.csv");
        }
        public IActionResult Details(int id)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

    }
}
