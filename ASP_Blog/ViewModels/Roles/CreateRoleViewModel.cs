using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Требуется ввести название роли.")]
        [Display(Name = "Введите название роли")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "Название роли должно содержать от {2} до {1} символов.", MinimumLength = 4)]
        public string RoleName { get; set; }
    }
}
