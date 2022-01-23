using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        public T Get(int id);

        public T Get(ISpecification<T> specification);

        public IList<T> List();

        public IList<T> List(ISpecification<T> specification);

        public T Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
