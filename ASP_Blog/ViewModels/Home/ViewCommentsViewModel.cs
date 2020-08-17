using ASP_Blog.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Home
{
    public class ViewCommentsViewModel
    {
        public News News { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
