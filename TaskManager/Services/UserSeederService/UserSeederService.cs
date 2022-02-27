using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManager.Models;
using TaskManager.Models.DbContext;
using Task = System.Threading.Tasks.Task;

namespace TaskManager.Services.UserSeederService
{
    public class UserSeederService
    {
        private readonly TaskManagerContext _context;

        public UserSeederService(TaskManagerContext context)
        {
            _context = context;
        }
        
        public async Task SeedUsers()
        {
            var rootUser = new User()
            {
                UserName = "GlobalAdmin",
                NormalizedUserName = "GLOBALADMIN",
                Email = "global.admin@taskmngr.com",
                NormalizedEmail = "GLOBAL.ADMIN@TASKMNGR.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            
            var employee = new User()
            {
                UserName = "employee",
                NormalizedUserName = "EMPLOYEE",
                Email = "employee@taskmngr.com",
                NormalizedEmail = "EMPLOYEE@TASKMNGR.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            if (!_context.Users.Any(u => u.UserName == rootUser.UserName))
            {
                var hasher = new PasswordHasher<User>();
                var hashed = hasher.HashPassword(rootUser, "gl0balAdm1n");
                rootUser.PasswordHash = hashed;
                hashed = hasher.HashPassword(employee, "pa$$w0rd");
                employee.PasswordHash = hashed;
                var userStore = new UserStore<User>(_context);
                await userStore.CreateAsync(rootUser);
                await userStore.AddToRoleAsync(rootUser, "ROOT");
                await userStore.CreateAsync(employee);
                await userStore.AddToRoleAsync(employee, "EMPLOYEE");
            }

            await _context.SaveChangesAsync();
        }
    }
}