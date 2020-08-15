using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.Models.Home
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentDate { get; set; }
        public string UserName { get; set; }
        public Guid NewsId { get; set; }
    }
}
