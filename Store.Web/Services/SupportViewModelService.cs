using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Web.Interfaces;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Services
{
    public class SupportViewModelService : ISupportViewModelService
    {
        private readonly IRepository<SupportMessage> messageRepository;
        private readonly IRepository<SupportCase> supportRepository;

        public SupportViewModelService(IRepository<SupportMessage> messageRepository, IRepository<SupportCase> supportRepository)
        {
            this.messageRepository = messageRepository;
            this.supportRepository = supportRepository;
        }

        public ICollection<SupportViewModel> GetAppeals()
        {
            var supCases = supportRepository.List().Select(ConvertToModel).ToList();
            foreach(var supCase in supCases)
            {
                supCase.Messages = messageRepository.List().Where(i => i.SupportCaseId == supCase.Id).Select(ConvertToModel).ToList();
            }

            return supCases;
        }

        public ICollection<SupportViewModel> GetMyAppeals(int userId)
        {
            var supCases = supportRepository.List().Where(i => i.InitiatorId == userId).Select(ConvertToModel).ToList();
            foreach (var supCase in supCases)
            {
                supCase.Messages = messageRepository.List().Where(i => i.SupportCaseId == supCase.Id).Select(ConvertToModel).ToList();
            }

            return supCases;
        }

        public SupportViewModel StartAppeal(int userId)
        {
            return ConvertToModel(supportRepository.Add(new SupportCase
            {
                Id = 0,
                InitiatorId = userId,
                Messages = null
            }));
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

        public SupportViewModel GoToAppeal(int caseId)
        {
            var supCases = supportRepository.List().FirstOrDefault(i => i.Id == caseId);
            var supCase = ConvertToModel(supCases);
            supCase.Messages = messageRepository.List().Where(i => i.SupportCaseId == supCase.Id).Select(ConvertToModel).ToList();

            return supCase;
        }

        private SupportViewModel ConvertToModel(SupportCase support)
        {
            return new SupportViewModel
            {
                Id = support.Id,
                InitiatorId = support.InitiatorId
            };
        }

        private SupportMessageViewModel ConvertToModel(SupportMessage message)
        {
            return new SupportMessageViewModel
            {
                Id = message.Id,
                Message = message.Message,
                Time = message.Time,
                MessageType = message.MessageType
            };
        }
    }
}
