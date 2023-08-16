using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPost_Application.DTOs.Post;

namespace BlogPost_Application.DTOs
{
    public class CommentEntityDTO
    {
        public int Post_Id { get; set; }

        public string? Text { get; set; }

        public virtual PostEntityDTO? Post { get; set; }
    }
}
