using Store.Core.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class SupportMessageViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }

        public SupportMessageType MessageType { get; set; }
    }
}
