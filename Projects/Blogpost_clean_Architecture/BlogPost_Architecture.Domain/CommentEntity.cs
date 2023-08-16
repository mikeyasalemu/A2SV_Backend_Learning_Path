using BlogPost_Architecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Architecture.Domain
{
    public class CommentEntity:BaseDomainEntity
    {
        public int Post_Id { get; set; }

        public string? Text { get; set; }

        public virtual PostEntity? Post { get; set; }
        
    }
}
