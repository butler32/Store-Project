using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class StoreViewModel
    {
        public ICollection<GameViewModel> TenGames { get; set; }
        public ICollection<GameViewModel> ElseGames { get; set; }
    }
}
