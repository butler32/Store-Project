using Store.Core.Entities;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Interfaces
{
    public interface ISupportViewModelService
    {
        ICollection<SupportViewModel> GetAppeals();
        ICollection<SupportViewModel> GetMyAppeals(int userId);
        SupportViewModel StartAppeal(int userId);
        void UserMessage(string message, int caseId);
        void SupportMessage(string message, int caseId);
        SupportViewModel GoToAppeal(int caseId);
    }
}
