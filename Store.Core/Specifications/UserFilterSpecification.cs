using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.Entities;
using Store.Core.Interfaces;

namespace Store.Core.Specifications
{
    class UserFilterSpecification : ISpecification<User>
    {
        public IList<string> Includes => throw new NotImplementedException();

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            throw new NotImplementedException();
        }
    }
}
