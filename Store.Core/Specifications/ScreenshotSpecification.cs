using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Specifications
{
    public class ScreenshotSpecification : ISpecification<Screenshot>
    {
        private int gameId;

        public ScreenshotSpecification(int gameId)
        {
            this.gameId = gameId;
        }

        public IList<string> Includes => new List<string> { $"{nameof(Screenshot.Image)}" };

        public IQueryable<Screenshot> Apply(IQueryable<Screenshot> query)
        {
            return query.Where(i => i.GameId == gameId);
        }
    }
}
