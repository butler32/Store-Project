using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class SupportViewModel
    {
        public int Id { get; set; }

        public int InitiatorId { get; set; }

        public string UserNickname { get; set; }

        public ICollection<SupportMessageViewModel> Messages { get; set; }
    }
}
