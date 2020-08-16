using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.Models.Home
{
    public class Gallery
    {
        public Guid Id { get; set; }
        public string GalleryTitle { get; set; }
        public string GalleryDescription { get; set; }
        public DateTime GalleryDate { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
