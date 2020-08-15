using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.Models.Home
{
    public class Image
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public Guid NewsId { get; set; }
    }
}
