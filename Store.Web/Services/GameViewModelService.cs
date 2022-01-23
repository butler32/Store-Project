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
    public class GameViewModelService : IGameViewModelService
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IGameService gameService;

        public GameViewModelService(IRepository<Game> gameRepository, IGameService gameService)
        {
            this.gameService = gameService;
            this.gameRepository = gameRepository;
        }

        public GameViewModel GetById(int id)
        {
            var game = gameService.Get(id);
            return game != null ? ConvertToViewModel(game) : null;
        }

        public IEnumerable<GameViewModel> GetTen()
        {
            Random random = new Random();
            return gameRepository.List().OrderBy(x => random.Next()).Take(10).Select(ConvertToViewModel);
        }

        private GameViewModel ConvertToViewModel(Game game)
        {
            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Discont = game.Discont,
                Developer = game.Developer
            };
        }
    }
}
