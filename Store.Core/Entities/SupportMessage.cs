using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entities
{
    public class SupportMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public SupportCase SupportCase { get; set; }
        public int SupportCaseId { get; set; }
        public DateTime Time { get; set; }
    }
}
