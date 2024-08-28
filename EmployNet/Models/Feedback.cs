using System;
using System.ComponentModel.DataAnnotations;

namespace EmployNet.Models
{
    public class Feedback
    {
        // Primary key for the Feedback entity
        [Key]
        public int Id { get; set; }

        // Name of the person providing feedback (required, max length 100 characters)
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Email address of the person providing feedback (required, must be a valid email format)
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Message content of the feedback (required, between 10 and 500 characters)
        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Message { get; set; }

        // Subject of the feedback (required, max length 100 characters)
        [Required]
        [StringLength(100)]
        public string Subject { get; set; }

        // Rating given in the feedback (optional, between 1 and 5)
        [Range(1, 5)]
        public int Rating { get; set; }

        // Timestamp when the feedback was submitted (default to current date and time)
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
