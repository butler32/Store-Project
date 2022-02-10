using System.Collections.Generic;

namespace Store.Core.Entities
{
    public class SupportCase
    {
        public int Id { get; set; }
        public int InitiatorId { get; set; }
        public User Initiator { get; set; }
        public ICollection<SupportMessage> Messages { get; set; }
    }
}