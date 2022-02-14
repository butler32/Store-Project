using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class SupportMessageByCaseIdSpecification : ISpecification<SupportMessage>
    {
        private int supCaseId;

        public SupportMessageByCaseIdSpecification(int supCaseId)
        {
            this.supCaseId = supCaseId;
        }

        public IList<string> Includes => null;

        public IQueryable<SupportMessage> Apply(IQueryable<SupportMessage> query)
        {
            return query.Where(i => i.SupportCaseId == supCaseId);
        }
    }
}
