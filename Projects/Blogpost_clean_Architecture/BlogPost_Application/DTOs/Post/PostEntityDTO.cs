using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Application.DTOs.Post
{
    public class PostEntityDTO
    {
        public PostEntityDTO()
        {
            Comments = new HashSet<CommentEntityDTO>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<CommentEntityDTO>? Comments { get; set; }

    }
}
