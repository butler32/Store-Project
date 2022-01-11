using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class Friend
    {
        public User FirstUser { get; set; }
        public int FirstUserId { get; set; }
        public User SecondUser { get; set; }
        public int SecondUserId { get; set; }
        public int Status { get; set; }
    }
}
