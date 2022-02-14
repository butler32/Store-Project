using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public class SupportService : ISupportService
    {
        private readonly IRepository<SupportMessage> messageRepository;
        private readonly IRepository<SupportCase> supportRepository;

        public SupportService(IRepository<SupportMessage> messageRepository, IRepository<SupportCase> supportRepository)
        {
            this.messageRepository = messageRepository;
            this.supportRepository = supportRepository;
        }

        public SupportCase StartAppeal(int userId)
        {
            return supportRepository.Add(new SupportCase
            {
                Id = 0,
                InitiatorId = userId,
                Messages = null
            });
        }

        public void SupportMessage(string message, int caseId)
        {
            messageRepository.Add(new SupportMessage
            {
                Id = 0,
                SupportCaseId = caseId,
                Time = DateTime.Now,
                Message = message,
                MessageType = Core.Entities.Enums.SupportMessageType.Support
            });
        }

        public void UserMessage(string message, int caseId)
        {
            messageRepository.Add(new SupportMessage
            {
                Id = 0,
                SupportCaseId = caseId,
                Time = DateTime.Now,
                Message = message,
                MessageType = Core.Entities.Enums.SupportMessageType.Initiator
            });
        }
    }
}
