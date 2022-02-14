using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Core.Entities;

namespace Store.Core.Specifications
{
    public class ImageByNameSpecification : ISpecification<Image>
    {
        private string imgName;

        public ImageByNameSpecification(string imgName)
        {
            this.imgName = imgName;
        }

        public IList<string> Includes => null;

        public IQueryable<Image> Apply(IQueryable<Image> query)
        {
            return query.Where(n => n.Name == imgName);
        }
    }
}
