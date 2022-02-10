using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class AccountPageViewModel
    {
        public ICollection<GameViewModel> Games { get; set; }
        public UserViewModel User { get; set; }
    }
}
