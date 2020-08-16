using ASP_Blog.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.ViewModels.Home
{
    public class GalleryViewModel
    {
        public Guid GalleryId { get; set; }
        public string GalleryTitle { get; set; }
        public string GalleryDescription { get; set; }
        public List<Image> Images { get; set; }
    }
}
