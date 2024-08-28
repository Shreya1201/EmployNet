using EmployNet.Data;
using EmployNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployNet.Controllers
{
    // Restrict access to this controller to users with the "User" role
    [Authorize(Roles = "User")]
    public class RequestLeaveController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject ApplicationDbContext
        public RequestLeaveController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Action to list all leave requests
        public IActionResult Index()
        {
            var leaves = _context.Leaves.ToList(); // Fetch all leave requests
            return View(leaves);
        }

        // Action to display the leave request creation form
        public IActionResult Create()
        {
            return View();
        }

        // Action to handle the form submission for creating a new leave request
        [HttpPost]
        public IActionResult Create(LeaveDto leaveDto)
        {
            // Check if the submitted form data is valid
            if (!ModelState.IsValid)
            {
                // If the data is not valid, return to the form view with the current data
                return View(leaveDto);
            }

            // Create a new Leave object and populate it with data from the DTO
            Leave leave = new Leave()
            {
                EmployeeName = leaveDto.EmployeeName,
                EmployeeId = leaveDto.EmployeeId,
                LeaveType = leaveDto.LeaveType,
                Reason = leaveDto.Reason,
                StartDate = leaveDto.StartDate,
                EndDate = leaveDto.EndDate,
                Status = leaveDto.Status,
            };

            // Add the new leave request to the database context
            _context.Leaves.Add(leave);
            // Save changes to the database
            _context.SaveChanges();

            // Redirect to the Index action of the Home controller after successful creation
            return RedirectToAction("Index", "Home");
        }
    }
}
