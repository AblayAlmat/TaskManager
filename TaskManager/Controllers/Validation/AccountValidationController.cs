using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models.DbContext;

namespace TaskManager.Controllers.Validation
{
    public class AccountValidationController : Controller
    {
        private readonly TaskManagerContext _context;

        public AccountValidationController(TaskManagerContext context)
        {
            _context = context;
        }

        [AcceptVerbs("GET", "POST")]
        public bool ValidateEmail(string email)
        {
            email = email.Trim().ToLower();
            return !_context.Users.Any(u => u.Email == email);
        }

        [AcceptVerbs("GET", "POST")]
        public bool ValidateUserName(string userName)
        {
            userName = userName.Trim().ToLower();
            return !_context.Users.Any(u => u.UserName == userName);
        }
    }
}