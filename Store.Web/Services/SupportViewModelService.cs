using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.Specifications;
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
        private readonly ISupportService supportService;

        public SupportViewModelService(ISupportService supportService, IRepository<SupportMessage> messageRepository, IRepository<SupportCase> supportRepository)
        {
            this.supportService = supportService;
            this.messageRepository = messageRepository;
            this.supportRepository = supportRepository;
        }

        public ICollection<SupportViewModel> GetAppeals()
        {
            var supCases = supportRepository.List().Select(ConvertToModel).ToList();
            foreach(var supCase in supCases)
            {
                supCase.Messages = messageRepository.List(new SupportMessageByCaseIdSpecification(supCase.Id)).Select(ConvertToModel).ToList();
            }

            return supCases;
        }

        public ICollection<SupportViewModel> GetMyAppeals(int userId)
        {
            var supCases = supportRepository.List(new SupportCaseByUserIdSpecification(userId)).Select(ConvertToModel).ToList();
            foreach (var supCase in supCases)
            {
                supCase.Messages = messageRepository.List(new SupportMessageByCaseIdSpecification(supCase.Id)).Select(ConvertToModel).ToList();
            }

            return supCases;
        }

        public SupportViewModel StartAppeal(int userId)
        {
            return ConvertToModel(supportService.StartAppeal(userId));
        }

        public void SupportMessage(string message, int caseId)
        {
            supportService.SupportMessage(message, caseId);
        }

        public void UserMessage(string message, int caseId)
        {
            supportService.UserMessage(message, caseId);
        }

        public SupportViewModel GoToAppeal(int caseId)
        {
            var supCases = supportRepository.Get(caseId);
            var supCase = ConvertToModel(supCases);
            supCase.Messages = messageRepository.List(new SupportMessageByCaseIdSpecification(supCases.Id)).Select(ConvertToModel).ToList();

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
