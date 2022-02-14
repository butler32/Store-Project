using System.Collections.Generic;

namespace Store.Core.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        public T Get(int id);

        public IList<T> List();

        public T Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public IList<T> List(ISpecification<T> specification);

        public T Get(ISpecification<T> specification);
    }
}
