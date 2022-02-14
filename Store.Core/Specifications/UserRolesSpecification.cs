using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class UserRolesSpecification : ISpecification<Member>
    {
        private int userId;

        public UserRolesSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => null;

        public IQueryable<Member> Apply(IQueryable<Member> query)
        {
            return query.Where(i => i.UserId == userId);
        }
    }
}
