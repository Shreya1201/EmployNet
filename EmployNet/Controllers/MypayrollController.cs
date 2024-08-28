using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EmployNet.Data;
using System.Text;
namespace EmployNet.Controllers
{
    [Authorize(Roles = "User")]
    public class MypayrollController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MypayrollController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Get the payrolls for the currently logged-in employee
            var payrolls = _context.Payrolls
                .Where(p => p.EmployeeId == 2)
                .ToList();

            // Pass the payrolls to the view
            return View(payrolls);
        }

        // Action to download payroll details as a CSV file
        public async Task<IActionResult> Download(int id)
        {

            // Fetch the payroll for the current user and specified payroll ID
            var payroll = await _context.Payrolls
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.Id == id && p.EmployeeId == 2);

            if (payroll == null)
            {
                return NotFound();
            }

            // Generate a CSV file with payroll details
            var csv = new StringBuilder();
            csv.AppendLine("Employee Name, Base Salary, Bonus, Deductions, Pay Date");
            csv.AppendLine($"{payroll.Employee.FirstName}, {payroll.BaseSalary}, {payroll.Bonus}, {payroll.Deductions}, {payroll.PayDate.ToShortDateString()}");

            var fileName = $"Payroll_{payroll.PayDate:yyyyMMdd}.csv";
            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", fileName);
        }
    }
}
