using EmployNet.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployNet.Models
{
    [Table("Payroll")]
    public class Payroll
    {
        // Primary key for the Payroll entity
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key referencing the Employee associated with the payroll
        [Required]
        public int EmployeeId { get; set; }

        // Navigation property for the related Employee
        [Required]
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        // Base salary of the employee
        [Required]
        [Precision(16, 2)]
        public decimal BaseSalary { get; set; }

        // Optional bonus amount
        [Precision(16, 2)]
        public decimal? Bonus { get; set; }

        // Optional deductions amount
        [Precision(16, 2)]
        public decimal? Deductions { get; set; }

        // Date of the payroll
        [Required]
        public DateTime PayDate { get; set; }

        // Computed property for the total pay
        [NotMapped]
        public decimal TotalPay
        {
            get
            {
                // Calculate total pay by adding base salary and bonus, then subtracting deductions
                return BaseSalary + (Bonus ?? 0) - (Deductions ?? 0);
            }
        }
    }
}
