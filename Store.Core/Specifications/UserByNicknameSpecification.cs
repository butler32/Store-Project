using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class UserByNicknameSpecification : ISpecification<User>
    {
        string nickname;

        public UserByNicknameSpecification(string nickname)
        {
            this.nickname = nickname;
        }

        public IList<string> Includes => null;

        public IQueryable<User> Apply(IQueryable<User> query)
        {
            throw new NotImplementedException();
        }
    }
}
