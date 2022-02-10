using Microsoft.AspNetCore.Mvc;
using Store.Web.Interfaces;
using Store.Web.Models;
using System.Linq;

namespace Store.Web.Controllers
{
    public class SupportController : Controller
    {
        private readonly IUserViewModelService userViewModelService;
        private readonly ISupportViewModelService supportViewModelService;

        public SupportController(ISupportViewModelService supportViewModelService, IUserViewModelService userViewModelService)
        {
            this.supportViewModelService = supportViewModelService;
            this.userViewModelService = userViewModelService;
        }

        public IActionResult Index()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(user);
        }

        public IActionResult GetAppeals()
        {
            return View(supportViewModelService.GetAppeals());
        }

        public IActionResult GetMyAppeals()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(supportViewModelService.GetMyAppeals(user.Id.Value));
        }

        public IActionResult StartAppeal()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(supportViewModelService.StartAppeal(user.Id.Value));
        }

        [HttpPost]
        public IActionResult SendMessage(string message, int caseId)
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            if (user.RoleIds.Contains(4) || user.RoleIds.Contains(3))
            {
                supportViewModelService.SupportMessage(message, caseId);
                return RedirectToAction("GoToAppeal", "Support", new { caseId = caseId });
            }
            else
            {
                supportViewModelService.UserMessage(message, caseId);
                return RedirectToAction("GoToAppeal", "Support", new { caseId = caseId });
            }
        }

        [HttpGet]
        public IActionResult GoToAppeal(int caseId)
        {
            return View(supportViewModelService.GoToAppeal(caseId));
        }

        private UserViewModel CheckUserLogIn()
        {
            var userClaims = HttpContext.User.Identity.Name;

            if (userClaims == null)
            {
                return null;
            }

            return userViewModelService.GetByName(userClaims);
        }
    }
}
