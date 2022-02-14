using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    class AcceptRequestSpecification : ISpecification<FriendRequest>
    {
        private int userId;
        private int secondUserId;

        public AcceptRequestSpecification(int userId, int secondUserId)
        {
            this.secondUserId = secondUserId;
            this.userId = userId;
        }

        public IList<string> Includes => null;

        public IQueryable<FriendRequest> Apply(IQueryable<FriendRequest> query)
        {
            return query.Where(i => i.RequestedById == secondUserId && i.RequestedToId == userId);
        }
    }
}
