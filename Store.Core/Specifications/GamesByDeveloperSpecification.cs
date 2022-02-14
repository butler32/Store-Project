using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class GamesByDeveloperSpecification : ISpecification<Game>
    {
        private int userId;

        public GamesByDeveloperSpecification(int userId)
        {
            this.userId = userId;
        }

        public IList<string> Includes => null;

        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.Where(i => i.DeveloperId == userId);
        }
    }
}
