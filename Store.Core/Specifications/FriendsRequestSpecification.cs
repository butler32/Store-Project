using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class FriendsRequestSpecification : ISpecification<FriendRequest>
    {
        private int userId;

        public FriendsRequestSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => null;

        public IQueryable<FriendRequest> Apply(IQueryable<FriendRequest> query)
        {
            return query
                .Where(i => i.RequestedById == userId)
                .Where(s => s.Status == Core.Entities.Enums.FriendRequestStatus.Accepted);
        }
    }
}
