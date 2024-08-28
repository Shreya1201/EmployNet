using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployNet.Models
{
    public class EmployeeDto
    {
        // Primary key with auto-increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // First name of the employee (required, max length 50 characters)
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        // Last name of the employee (required, max length 50 characters)
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        // Email address of the employee (required, must be a valid email, max length 100 characters)
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        // Phone number of the employee (required, must be a valid phone number, max length 10 characters)
        [Required]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        // Address of the employee (required, max length 100 characters)
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        // Department in which the employee works (required, max length 50 characters)
        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        // Position of the employee (required, max length 50 characters)
        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        // Date of birth of the employee (required)
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Date when the employee joined the company (required)
        [Required]
        public DateTime DateOfJoining { get; set; }
    }
}
