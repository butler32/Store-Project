using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class GameByNameSpecification : ISpecification<Game>
    {
        private string name;

        public GameByNameSpecification(string name)
        {
            this.name = name;
        }

        public IList<string> Includes => null;

        public IQueryable<Game> Apply(IQueryable<Game> query)
        {
            return query.Where(n => n.Name == name);
        }
    }
}
