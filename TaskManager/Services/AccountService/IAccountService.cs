using System.Threading.Tasks;
using TaskManager.ViewModels.Account;

namespace TaskManager.Services.AccountService
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(RegisterViewModel model);
        public Task<bool> LoginAsync(LoginViewModel model);
        public Task LogOut();
    }
}