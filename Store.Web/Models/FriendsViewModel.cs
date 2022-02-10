using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class FriendsViewModel
    {
        public ICollection<UserViewModel> FriendsRequested { get; set; }
        public ICollection<UserViewModel> FriendsRecieved { get; set; }
    }
}
