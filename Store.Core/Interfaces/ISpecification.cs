using System.Collections.Generic;
using System.Linq;

namespace Store.Core.Interfaces
{
    public interface ISpecification<T>
        where T : class
    {
        IList<string> Includes { get; }

        IQueryable<T> Apply(IQueryable<T> query);
    }
}
