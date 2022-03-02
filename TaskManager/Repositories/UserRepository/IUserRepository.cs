using TaskManager.Models;

namespace TaskManager.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public User GetById(string id);
    }
}