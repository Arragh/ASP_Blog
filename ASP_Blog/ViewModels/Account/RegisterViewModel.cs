using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Требуется ввести имя пользователя.")]
        [Display(Name = "Имя пользователя")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Имя пользователя должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Требуется ввести адрес Email.")]
        [Display(Name = "Адрес Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Введите корректный адрес Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Требуется ввести пароль.")]
        [Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть от {2} до {1} символов", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Требуется повторить пароль.")]
        [Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string PasswordConfirm { get; set; }
    }
}
