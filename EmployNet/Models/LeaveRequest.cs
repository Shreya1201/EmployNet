using EmployNet.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployNet.Models
{
    public class LeaveRequest
    {
        // Primary key for the LeaveRequest entity
        public int LeaveRequestId { get; set; }

        // Foreign key referencing the User who created the leave request
        public string UserId { get; set; }

        // The start date of the leave
        public DateTime StartDate { get; set; }

        // The end date of the leave
        public DateTime EndDate { get; set; }

        // Reason for the leave request
        public string Reason { get; set; }

        // Status of the leave request (e.g., Pending, Approved, Rejected)
        public string Status { get; set; }

        // Navigation property for the related User
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        // Navigation property for the related LeaveApproval
        public virtual LeaveApproval LeaveApproval { get; set; }
    }
}
