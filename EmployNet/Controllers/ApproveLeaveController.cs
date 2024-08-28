using EmployNet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployNet.Controllers
{
    // Restrict access to this controller to users with the "Manager" role
    [Authorize(Roles = "Manager")]
    public class ApproveLeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the ApplicationDbContext
        public ApproveLeaveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to list all pending leave requests
        public IActionResult Index()
        {
            // Fetch all leave requests with a status of "Pending"
            var pendingLeaveRequests = _context.Leaves
                                               .Where(l => l.Status == "Pending")
                                               .ToList();
            // Pass the list of pending leave requests to the view
            return View(pendingLeaveRequests);
        }

        // Action to approve a leave request
        [HttpPost]
        public IActionResult Approve(int id)
        {
            // Find the leave request by its ID
            var leaveRequest = _context.Leaves.Find(id);

            // If the leave request exists and its status is "Pending"
            if (leaveRequest != null && leaveRequest.Status == "Pending")
            {
                // Update the status to "Approved"
                leaveRequest.Status = "Approved";

                // Save the changes to the database
                _context.SaveChanges();
            }

            // Redirect to the Index action to display the updated list
            return RedirectToAction("Index");
        }

        // Action to reject a leave request
        [HttpPost]
        public IActionResult Reject(int id)
        {
            // Find the leave request by its ID
            var leaveRequest = _context.Leaves.Find(id);

            // If the leave request exists and its status is "Pending"
            if (leaveRequest != null && leaveRequest.Status == "Pending")
            {
                // Update the status to "Rejected"
                leaveRequest.Status = "Rejected";

                // Save the changes to the database
                _context.SaveChanges();
            }

            // Redirect to the Index action to display the updated list
            return RedirectToAction("Index");
        }
    }
}
