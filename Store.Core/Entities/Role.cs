using System.Collections.Generic;

namespace Store.Core.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public bool Name { get; set; }
        public ICollection<Member> Members { get; set; }
    }
}
