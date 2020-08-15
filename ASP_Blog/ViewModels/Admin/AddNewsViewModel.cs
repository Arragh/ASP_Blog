using ASP_Blog.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Admin
{
    public class AddNewsViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести заголовок.")]
        [Display(Name = "Заголовок")]
        [StringLength(100, ErrorMessage = "Длина заголовка должна быть от {1} до {2} символов.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        public string NewsTitle { get; set; }

        [Required(ErrorMessage = "Содержание не может быть пустым.")]
        [Display(Name = "Содержание")]
        [StringLength(5000, ErrorMessage = "Длина содержания должна быть от {1} до {2} символов.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string NewsBody { get; set; }

        [Display(Name = "Загрузить изображение")]
        public Image NewsImage { get; set; }
    }
}
