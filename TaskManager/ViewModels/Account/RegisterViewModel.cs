using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [Remote("ValidateUserName", "AccountValidation", ErrorMessage = "Введенное имя пользователя занято")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Введите адрес эл.почты")]
        [Remote("ValidateEmail", "AccountValidation", ErrorMessage = "Введенный адрес почты занят")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
        public string Role { get; set; }
    }
}