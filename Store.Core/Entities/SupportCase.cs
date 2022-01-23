using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class SupportCase
    {
        public int Id { get; set; }
        public int InitiatorId { get; set; }
        public User Initiator { get; set; }
        public int SupportId { get; set; }
        public User Support { get; set; }
        public ICollection<SupportMessage> Messages { get; set; }
    }
}