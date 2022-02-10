using System.Collections.Generic;

namespace Store.Core.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Discont { get; set; }
        public bool IsApproved { get; set; }
        public string Developer { get; set; }
        public int DeveloperId { get; set; }
        public ICollection<Screenshot> Screenshots { get; set; }
        public ICollection<Libriary> Libriaries { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
