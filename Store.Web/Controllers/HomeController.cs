using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Web.Interfaces;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameViewModelService gameViewModelService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGameViewModelService gameViewModelService)
        {
            _logger = logger;
            this.gameViewModelService = gameViewModelService;
        }

        public IActionResult Index()
        {
            var games = gameViewModelService.GetTen();
            return View(games);
        }

        public IActionResult Libriary()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
