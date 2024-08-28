using EmployNet.Data;
using EmployNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployNet.Controllers
{
    [Authorize(Roles = "Manager, Admin")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // List all employees
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        // Display form to create a new employee
        public IActionResult Create()
        {
            return View();
        }

        // Handle form submission to create a new employee
        [HttpPost]
        public IActionResult Create(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            Employee employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                Address = employeeDto.Address,
                Department = employeeDto.Department,
                Position = employeeDto.Position,
                DateOfBirth = employeeDto.DateOfBirth,
                DateOfJoining = employeeDto.DateOfJoining
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        // Display form to edit an existing employee
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            var employeeDto = new EmployeeDto()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Department = employee.Department,
                Position = employee.Position,
                DateOfBirth = employee.DateOfBirth,
                DateOfJoining = employee.DateOfJoining
            };

            ViewData["id"] = employee.Id;
            return View(employeeDto);
        }

        // Handle form submission to edit an existing employee
        [HttpPost]
        public IActionResult Edit(int id, EmployeeDto employeeDto)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            if (!ModelState.IsValid)
            {
                ViewData["id"] = employee.Id;
                return View(employeeDto);
            }

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.Email = employeeDto.Email;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.Address = employeeDto.Address;
            employee.Department = employeeDto.Department;
            employee.Position = employeeDto.Position;
            employee.DateOfBirth = employeeDto.DateOfBirth;
            employee.DateOfJoining = employeeDto.DateOfJoining;
            _context.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }

        // Delete an existing employee

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}
