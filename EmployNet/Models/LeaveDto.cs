using System.ComponentModel.DataAnnotations;

namespace EmployNet.Models
{
    /// <summary>
    /// Data Transfer Object for Leave requests.
    /// </summary>
    public class LeaveDto
    {
        /// <summary>
        /// Gets or sets the Employee ID.
        /// </summary>
        [Required]
        public int EmployeeId { get; set; } = 3;

        /// <summary>
        /// Gets or sets the name of the Employee.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; } = "Radha Singh";

        /// <summary>
        /// Gets or sets the type of leave requested.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LeaveType { get; set; }

        /// <summary>
        /// Gets or sets the reason for the leave request.
        /// </summary>
        [Required]
        [StringLength(500)]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets the start date of the leave.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the leave.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the current status of the leave request.
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";
    }
}
