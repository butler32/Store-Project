using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Core.Interfaces;
using Store.Web.Interfaces;
using Store.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserViewModelService userViewModelService;
        private readonly IGameViewModelService gameViewModelService;
        private readonly IUserService userService;
        private readonly IPasswordHasher passwordHasher;

        public AccountController(IGameViewModelService gameViewModelService, IUserViewModelService userViewModelService, IUserService userService, IPasswordHasher passwordHasher)
        {
            this.gameViewModelService = gameViewModelService;
            this.userViewModelService = userViewModelService;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userClaims = HttpContext.User.Identity.Name;
            var userCheck = userService.Get(userClaims);

            if (userCheck != null)
            {
                return RedirectToAction(nameof(AccountPage), "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LogInViewModel logInViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(logInViewModel);
            }

            var user = userService.Get(logInViewModel.Login);
            if (user == null || !passwordHasher.IsValid(logInViewModel.Password, user.Password, user.Salt))
            {
                ModelState.AddModelError(string.Empty, "Invalid login or password");
                return View(logInViewModel);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.SerialNumber, user.Balance.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Login));
           // claims.AddRange(user.Members.Select(m => new Claim(ClaimTypes.Role, m.Role.Name)));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return string.IsNullOrEmpty(returnUrl)
                ? RedirectToAction("Index", "Home")
                : Redirect(returnUrl);
        }

        public IActionResult AccountPage()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            var games = gameViewModelService.GetLibriary(user.Id.Value);


            return View(new AccountPageViewModel
            {
                User = user,
                Games = games
            });
        }

        public IActionResult ElseAccountPage(int userId)
        {
            var user = userViewModelService.GetById(userId);

            var games = gameViewModelService.GetLibriary(user.Id.Value);


            return View(new AccountPageViewModel
            {
                User = user,
                Games = games
            });
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Friends()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            var friends = userViewModelService.GetFriends(user.Id.Value);
            return View(friends);
        }

        public IActionResult RequestedFriends()
        {
            var user = CheckUserLogIn();

            var friends = userViewModelService.RequestedFriends(user.Id.Value);

            return View(friends);
        }

        [HttpPost]
        public IActionResult AddFriend(int elseUserId)
        {
            var user = CheckUserLogIn();
            userViewModelService.SendRequest(user.Id.Value, elseUserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult AcceptFriend(int elseUserId)
        {
            var user = CheckUserLogIn();
            userViewModelService.AcceptRequest(user.Id.Value, elseUserId);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SearchFriend(string name)
        {
            var users = userViewModelService.SearchFriend(name);
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(SignInViewModel signIn, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(signIn);
            }

            if (signIn.Password != signIn.PasswordAgain)
            {
                ModelState.AddModelError(string.Empty, "Passwords must be the same");
                return View(signIn);
            }

            if (userViewModelService.IsLoginUnique(signIn.Login))
            {
                ModelState.AddModelError(string.Empty, "This login is already registered");
                return View(signIn);
            }

            userViewModelService.Add(signIn);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel editProfile)
        {
            var userClaims = HttpContext.User.Identity.Name;
            var user = userViewModelService.GetByName(userClaims);

            userViewModelService.Edit(editProfile, user);

            return RedirectToAction("AccountPage", "Account");
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
