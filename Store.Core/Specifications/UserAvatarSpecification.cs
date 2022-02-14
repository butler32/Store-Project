using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class UserAvatarSpecification : ISpecification<Avatar>
    {
        int userId;

        public UserAvatarSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => new List<string> { $"{nameof(Avatar.Image)}" };

        public IQueryable<Avatar> Apply(IQueryable<Avatar> query)
        {
            return query.Where(i => i.UserId == userId);
        }
    }
}
