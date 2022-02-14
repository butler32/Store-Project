using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class CartSpecification : ISpecification<Cart>
    {
        private int userId;

        public CartSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => new List<string> { $"{nameof(Libriary.Game)}" };

        public IQueryable<Cart> Apply(IQueryable<Cart> query)
        {
            return query.Where(i => i.UserId == userId);
        }
    }
}
