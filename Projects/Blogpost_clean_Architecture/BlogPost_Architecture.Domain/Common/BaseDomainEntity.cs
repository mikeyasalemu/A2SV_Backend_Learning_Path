using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost_Architecture.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
