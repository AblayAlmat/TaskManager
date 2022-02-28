using System.Threading.Tasks;
using TaskManager.ViewModels;

namespace TaskManager.Services.AccountService
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(RegisterViewModel model);
    }
}