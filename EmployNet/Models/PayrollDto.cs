using System.ComponentModel.DataAnnotations;

namespace EmployNet.Models
{
    public class PayrollDto
    {
        // ID of the Employee associated with the payroll
        [Required]
        public int EmployeeId { get; set; }

        // Base salary of the employee, must be a positive number
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Base Salary must be a positive number.")]
        public decimal BaseSalary { get; set; }

        // Optional bonus amount, must be a positive number
        [Range(0, double.MaxValue)]
        public decimal? Bonus { get; set; }

        // Optional deductions amount, must be a positive number
        [Range(0, double.MaxValue)]
        public decimal? Deductions { get; set; }

        // Date of the payroll
        [Required]
        public DateTime PayDate { get; set; }
    }
}
