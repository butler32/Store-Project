using Microsoft.AspNetCore.Mvc;
using Store.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IGameViewModelService gameViewModelService;

        public StoreController(IGameViewModelService gameViewModelService)
        {
            this.gameViewModelService = gameViewModelService;
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

        public IActionResult Cart()
        {
            return View();
        }
    }
}
