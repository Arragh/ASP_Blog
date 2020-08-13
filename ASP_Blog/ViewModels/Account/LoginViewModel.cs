using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя пользователя.")]
        [Display(Name = "Введите имя пользователя")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Имя пользователя должно быть от {2} до {1} символов", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль.")]
        [Display(Name = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть от {2} до {1} символов", MinimumLength = 6)]
        public string Password { get; set; }

        [Display(Name = "Запомнить")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
