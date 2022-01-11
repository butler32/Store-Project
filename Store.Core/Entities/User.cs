using System.Collections.Generic;

namespace Store.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Member> Members { get; set; } 
        public ICollection<FriendRequest> SentFriendRequests { get; set; }
        public ICollection<FriendRequest> ReceievedFriendRequests { get; set; }
        public ICollection<SupportCase> InitiatedСases { get; set; }
        public ICollection<SupportCase> SupportedСases { get; set; }
    }
}
