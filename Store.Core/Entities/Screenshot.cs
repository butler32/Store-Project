using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Screenshot
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

    }
}
