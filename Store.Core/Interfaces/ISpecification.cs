using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    interface ISpecification<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> query);
    }
}
