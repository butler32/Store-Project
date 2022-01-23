using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discont { get; set; }
        public bool Approved { get; set; }
        public string Developer { get; set; }
        public ICollection<Libriary> Libriaries { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
