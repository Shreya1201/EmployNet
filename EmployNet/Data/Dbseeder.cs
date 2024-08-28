using EmployNet.Constants;
using EmployNet.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AspnetIdentityRoleBasedTutorial.Data
{
    public static class DbSeeder
    {
        // Method to seed roles and create default users
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();

            // Ensure RoleManager and UserManager are available
            if (roleManager == null || userManager == null)
                throw new Exception("RoleManager or UserManager is not registered in the services.");

            // Seed Roles
            // Create Admin role if it does not exist
            if (!await roleManager.RoleExistsAsync(Roles.Admin.ToString()))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            // Create User role if it does not exist
            if (!await roleManager.RoleExistsAsync(Roles.User.ToString()))
                await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Create Finance role if it does not exist
            if (!await roleManager.RoleExistsAsync(Roles.Finance.ToString()))
                await roleManager.CreateAsync(new IdentityRole(Roles.Finance.ToString()));

            // Create Manager role if it does not exist
            if (!await roleManager.RoleExistsAsync(Roles.Manager.ToString()))
                await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));

            // Create Admin User
            var admin = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Ravindra Singh",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(admin.Email);
            if (userInDb == null)
            {
                // Create Admin user and assign Admin role
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
            }

            // Create Manager User
            var manager = new ApplicationUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                Name = "Rekha Sharma",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb2 = await userManager.FindByEmailAsync(manager.Email);
            if (userInDb2 == null)
            {
                // Create Manager user and assign Manager role
                await userManager.CreateAsync(manager, "Manager@123");
                await userManager.AddToRoleAsync(manager, Roles.Manager.ToString());
            }

            // Create Finance User
            var finance = new ApplicationUser
            {
                UserName = "finance@gmail.com",
                Email = "finance@gmail.com",
                Name = "Hemant Sharma",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb3 = await userManager.FindByEmailAsync(finance.Email);
            if (userInDb3 == null)
            {
                // Create Finance user and assign Finance role
                await userManager.CreateAsync(finance, "Finance@123");
                await userManager.AddToRoleAsync(finance, Roles.Finance.ToString());
            }

            // Create Employee User
            var user = new ApplicationUser
            {
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                Name = "Radha Singh",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb4 = await userManager.FindByEmailAsync(user.Email);
            if (userInDb4 == null)
            {
                // Create Regular user and assign User role
                await userManager.CreateAsync(user, "User@123");
                await userManager.AddToRoleAsync(user, Roles.User.ToString());
            }
        }
    }
}
