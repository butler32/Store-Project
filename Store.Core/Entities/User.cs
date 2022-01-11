using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Role> Roles { get; set; }
        //public ICollection<Friend> UsersFriends { get; set; }
    }
}
