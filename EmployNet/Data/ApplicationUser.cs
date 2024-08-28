using EmployNet.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EmployNet.Data
{
    // ApplicationUser class extending IdentityUser to include additional properties
    public class ApplicationUser : IdentityUser
    {
        // Additional properties for the user
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
