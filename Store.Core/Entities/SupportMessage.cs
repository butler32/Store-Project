using Store.Core.Entities.Enums;
using System;

namespace Store.Core.Entities
{
    public class SupportMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public SupportCase SupportCase { get; set; }
        public int SupportCaseId { get; set; }
        public DateTime Time { get; set; }
        public SupportMessageType MessageType { get; set; }
    }
}