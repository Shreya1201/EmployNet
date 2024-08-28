using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployNet.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Primary key with auto-increment
        public int Id { get; set; }

        [Required]
        // Employee ID associated with the leave request
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        // Name of the employee requesting leave
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(20)]
        // Type of leave being requested (e.g., Sick, Vacation)
        public string LeaveType { get; set; }

        [Required]
        [StringLength(500)]
        // Reason for the leave request
        public string Reason { get; set; }

        [Required]
        // Start date of the leave
        public DateTime StartDate { get; set; }

        [Required]
        // End date of the leave
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        // Status of the leave request (e.g., Pending, Approved, Rejected)
        public string Status { get; set; }
    }
}
