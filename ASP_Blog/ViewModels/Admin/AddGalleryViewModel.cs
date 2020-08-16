using ASP_Blog.Models.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Admin
{
    public class AddGalleryViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести название для галереи.")]
        [Display(Name = "Название")]
        [StringLength(100, ErrorMessage = "Название галереи должно быть от 2 до 100 символов.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        public string GalleryTitle { get; set; }

        [Required(ErrorMessage = "Введите краткое описание галереи.")]
        [Display(Name = "Краткое описание")]
        [StringLength(500, ErrorMessage = "Краткое описание должно быть от 10 до 500 символов.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string GalleryDescription { get; set; }
    }
}
