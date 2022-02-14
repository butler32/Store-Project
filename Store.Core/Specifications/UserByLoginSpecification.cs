using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.Entities;
using Store.Core.Interfaces;

namespace Store.Core.Specifications
{
    class UserByLoginSpecification : ISpecification<User>
    {
        private string login;

        public UserByLoginSpecification(string login)
        {
            this.login = login;
        }

        public IList<string> Includes => new List<string> { $"{nameof(User.Members)}.{nameof(Member.Role)}" };

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            return query.Where(i => i.Login == login);
        }
    }
}
