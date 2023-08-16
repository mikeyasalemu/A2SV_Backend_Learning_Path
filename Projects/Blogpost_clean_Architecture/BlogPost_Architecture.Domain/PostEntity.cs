using BlogPost_Architecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Architecture.Domain
{
    public class PostEntity : BaseDomainEntity
    {
        public PostEntity()
        {
            Comments = new HashSet<CommentEntity>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<CommentEntity>? Comments { get; set; }
    }
}
