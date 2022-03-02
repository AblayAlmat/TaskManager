using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskManager.Models;
using TaskManager.ViewModels.Account;

namespace TaskManager.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(
            IMapper mapper, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                await _signInManager.SignInAsync(user, false);
                return true;
            }

            return false;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Login);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                return result.Succeeded;
            }

            user = await _userManager.FindByEmailAsync(model.Login);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                return result.Succeeded;
            }

            return false;
        }
    }
}