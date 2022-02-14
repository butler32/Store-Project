using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class LibriarySpecification : ISpecification<Libriary>
    {
        private int userId;

        public LibriarySpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => new List<string> { $"{nameof(Libriary.Game)}"};

        public IQueryable<Libriary> Apply(IQueryable<Libriary> query)
        {
            return query.Where(i => i.UserId == userId);
        }
    }
}
