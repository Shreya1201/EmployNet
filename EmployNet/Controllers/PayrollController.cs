using EmployNet.Data;
using EmployNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Authorize(Roles = "Finance")]
public class PayrollController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor to initialize the database context
    public PayrollController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Display a list of payroll entries
    public IActionResult Index()
    {
        var payrolls = _context.Payrolls.Include(p => p.Employee).ToList();
        return View(payrolls);
    }

    // Display form to create a new payroll entry
    public IActionResult Create()
    {
        return View();
    }

    // Handle form submission to create a new payroll entry
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PayrollDto payrollDto)
    {
        if (ModelState.IsValid)
        {
            // Check if the EmployeeId exists in the Employee table
            var employeeExists = _context.Employees.Any(e => e.Id == payrollDto.EmployeeId);
            if (!employeeExists)
            {
                ModelState.AddModelError("EmployeeId", "The Employee ID provided does not exist.");
                return View(payrollDto);
            }

            // Check for existing payroll with the same EmployeeId and PayDate
            var payrollExists = _context.Payrolls
                .Any(p => p.EmployeeId == payrollDto.EmployeeId && p.PayDate.Date == payrollDto.PayDate.Date);
            if (payrollExists)
            {
                ModelState.AddModelError("PayDate", "A payroll entry for this employee on the given date already exists.");
                return View(payrollDto);
            }

            // Create a new Payroll record
            var payroll = new Payroll
            {
                EmployeeId = payrollDto.EmployeeId,
                BaseSalary = payrollDto.BaseSalary,
                Bonus = payrollDto.Bonus,
                Deductions = payrollDto.Deductions,
                PayDate = payrollDto.PayDate,

            };

            // Add the payroll entry to the database
            _context.Add(payroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Return the view with validation errors if ModelState is not valid
        return View(payrollDto);
    }

    // Display form to edit an existing payroll entry
    public IActionResult Edit(int id)
    {
        var payroll = _context.Payrolls.Find(id);
        if (payroll == null)
        {
            return RedirectToAction("Index", "Payroll");
        }

        var payrollDto = new PayrollDto()
        {
            BaseSalary = payroll.BaseSalary,
            Bonus = payroll.Bonus,
            Deductions = payroll.Deductions,
            PayDate = payroll.PayDate
        };

        ViewData["id"] = payroll.Id;
        return View(payrollDto);
    }

    // Handle form submission to edit an existing payroll entry
    [HttpPost]
    public IActionResult Edit(int id, PayrollDto payrollDto)
    {
        var payroll = _context.Payrolls.Find(id);

        if (payroll == null)
        {
            return RedirectToAction("Index", "Payroll");
        }

        if (!ModelState.IsValid)
        {
            ViewData["id"] = payroll.Id;
            return View(payrollDto);
        }

        payroll.BaseSalary = payrollDto.BaseSalary;
        payroll.Bonus = payrollDto.Bonus;
        payroll.Deductions = payrollDto.Deductions;
        payroll.PayDate = payrollDto.PayDate;
        _context.SaveChanges();
        return RedirectToAction("Index", "Payroll");
    }

    // Handle form submission to delete a payroll entry
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var payroll = _context.Payrolls.Find(id);
        if (payroll != null)
        {
            _context.Payrolls.Remove(payroll);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
