using System.Linq;
using TaskManager.Models;
using TaskManager.Models.DbContext;

namespace TaskManager.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskManagerContext _context;

        public UserRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public User GetById(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}