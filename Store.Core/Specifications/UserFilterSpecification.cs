using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Entities;
using Store.Core.Interfaces;

namespace Store.Core.Specifications
{
    class UserFilterSpecification : ISpecification<User>
    {

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            throw new NotImplementedException();
        }
    }
}
