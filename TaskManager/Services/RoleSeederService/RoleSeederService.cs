using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TaskManager.Models.DbContext;

namespace TaskManager.Services.RoleSeederService
{
    public class RoleSeederService
    {
        private readonly TaskManagerContext _context;

        public RoleSeederService(TaskManagerContext context)
        {
            _context = context;
        }

        public async Task SeedRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            var roles = new[]
            {
                new IdentityRole() {Name = "Root", NormalizedName = "ROOT"},
                    new IdentityRole() {Name = "Employee", NormalizedName = "EMPLOYEE"},
                new IdentityRole() {Name = "User", NormalizedName = "USER"}
            };
            foreach (var role in roles)
            {
                if (!_context.Roles.Any(r => r.Name == role.Name))
                {
                    await roleStore.CreateAsync(role);
                }
            }
            
            await _context.SaveChangesAsync();
        }
    }
}