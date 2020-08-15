using ASP_Blog.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Home
{
    public class IndexViewModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<News> News { get; set; }
        public List<Image> Images { get; set; }
    }
}
