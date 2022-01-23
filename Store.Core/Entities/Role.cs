using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public bool Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}