using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class SupportCase
    {
        public int UserId { get; set; }
        public ICollection<User> User { get; set; }
        public int SupportId { get; set; }
        public ICollection<User> Support { get; set; }
        public int MessageId { get; set; }
        public ICollection<SupportMessage> Messages { get; set; }
    }
}
