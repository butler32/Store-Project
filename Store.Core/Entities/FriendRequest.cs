using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Store.Core.Entities.Enums;

namespace Store.Core.Entities
{
    public class FriendRequest
    {
        public User RequestedBy { get; set; }
        public int RequestedById { get; set; }
        public User RequestedTo { get; set; }
        public int RequestedToId { get; set; }
        public FriendRequestStatus Status { get; set; }
    }
}