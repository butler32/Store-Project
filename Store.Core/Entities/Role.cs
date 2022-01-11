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
        public bool IsAdmin { get; set; }
        public bool IsSupport { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsModerator { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
