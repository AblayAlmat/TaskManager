using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Services.AccountService;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _accountService.RegisterAsync(model);
                    if (result)
                    {
                        return RedirectToAction("Index", "Task");
                    }
                    ModelState.AddModelError("", "Не удалось создать пользователя");
                }
                
                return View(model);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        
    }
}