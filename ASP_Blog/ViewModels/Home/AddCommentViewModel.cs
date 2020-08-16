using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Home
{
    public class AddCommentViewModel
    {
        [Required(ErrorMessage = "Комментарий не может быть пустым.")]
        [Display(Name = "Комментировать")]
        [StringLength(3000, ErrorMessage = "Длина комментария должна быть от {1} да {2} символов.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string CommentBody { get; set; }
        public Guid TargetId { get; set; }
    }
}
