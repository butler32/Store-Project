using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    interface IRepository<TEntity> 
        where TEntity : class
    {
        public TEntity Get(int id);

        public IList<TEntity> Get(ISpecification<TEntity> specification);
    }
}
