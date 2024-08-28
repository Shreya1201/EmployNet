using EmployNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployNet.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for each entity in the application
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Leave> Leaves { get; set; }
    }
}
