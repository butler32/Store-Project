using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class SupportCaseByUserIdSpecification : ISpecification<SupportCase>
    {
        private int userId;

        public SupportCaseByUserIdSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => null;

        public IQueryable<SupportCase> Apply(IQueryable<SupportCase> query)
        {
            return query.Where(i => i.InitiatorId == userId);
        }
    }
}
