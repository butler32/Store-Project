using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Store.Web.Interfaces;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGameViewModelService gameViewModelService;
        private readonly IUserViewModelService userViewModelService;

        public StoreController(IGameViewModelService gameViewModelService, IUserViewModelService userViewModelService)
        {
            this.gameViewModelService = gameViewModelService;
            this.userViewModelService = userViewModelService;
        }

        [HttpGet]
        public IActionResult GamePage(int id)
        {
            var game = gameViewModelService.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddGame(GameViewModel game)
        {
            if (!ModelState.IsValid)
            {
                return View(game);
            }

            var userClaims = HttpContext.User.Identity.Name;
            var user = userViewModelService.GetByName(userClaims);
            game.DeveloperId = user.Id.Value;
            game.Id = gameViewModelService.Add(game);

            return RedirectToAction("AccountPage", "Account");
        }

        [HttpPost]
        public IActionResult Approve(int gameId)
        {
            gameViewModelService.Approve(gameId);

            return RedirectToAction("CheckNotApprovedGames", "Store");
        }

        [HttpPost]
        public IActionResult NotApprove(int gameId)
        {
            gameViewModelService.NotApprove(gameId);

            return RedirectToAction("CheckNotApprovedGames", "Store");
        }

        public IActionResult CheckNotApprovedGames()
        {
            var game = gameViewModelService.GetUnapprovedGame();

            if(game == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(game);
        }

        public IActionResult Cart()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(gameViewModelService.GetCart(user.Id.Value));
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            gameViewModelService.AddToCart(user.Id.Value, id);

            return RedirectToAction("Cart", "Store");
        }

        [HttpGet]
        public IActionResult BuyFromCart()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            gameViewModelService.BuyFromCart(user.Id.Value);
            return RedirectToAction("Libriary", "Store");
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int gameId)
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            gameViewModelService.DeleteFromCart(user.Id.Value, gameId);
            return RedirectToAction("Cart", "Store");
        }

        public IActionResult Libriary()
        {
            var user = CheckUserLogIn();
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(gameViewModelService.GetLibriary(user.Id.Value));
        }

        [HttpGet]
        public IActionResult MakeDiscont()
        {
            var user = CheckUserLogIn();

            var game = gameViewModelService.GetGamesByDeveloper(user.Id.Value);
            return View(game);
        }

        [HttpPost]
        public IActionResult MakeDiscont(int gameId, float discont)
        {
            gameViewModelService.MakeDiscont(gameId, discont);

            return RedirectToAction("AccountPage", "Account"); ;
        }

        [HttpPost]
        public IActionResult SearchGame(string name)
        {
            var games = gameViewModelService.SearchGame(name);
            return View(games);
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
