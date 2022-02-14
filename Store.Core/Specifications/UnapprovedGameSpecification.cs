using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class UnapprovedGameSpecification : ISpecification<Game>
    {
        public IList<string> Includes => null;

        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.Where(b => b.IsApproved == false);
        }
    }
}
