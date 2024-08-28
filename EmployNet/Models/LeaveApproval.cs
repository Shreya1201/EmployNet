using EmployNet.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployNet.Models
{
    public class LeaveApproval
    {
        // Primary key for the LeaveApproval entity
        public int LeaveApprovalId { get; set; }

        // Foreign key referencing the related LeaveRequest
        public int LeaveRequestId { get; set; }

        // Foreign key referencing the Manager who approved/rejected the leave request
        public string ManagerId { get; set; }

        // Date when the leave request was approved/rejected
        public DateTime ApprovalDate { get; set; }

        // Additional comments from the Manager regarding the leave approval/rejection
        public string Comments { get; set; }

        // Navigation property for the related LeaveRequest
        [ForeignKey("LeaveRequestId")]
        public virtual LeaveRequest LeaveRequest { get; set; }

        // Navigation property for the Manager who handled the approval/rejection
        [ForeignKey("ManagerId")]
        public virtual ApplicationUser Manager { get; set; }
    }
}
