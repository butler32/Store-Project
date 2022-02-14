using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.Specifications;
using Store.Web.Interfaces;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Store.Web.Services
{
    public class GameViewModelService : IGameViewModelService
    {
        private const string jpgExtension = ".jpg";

        private readonly IRepository<User> userRepository;
        private readonly IRepository<Libriary> libriaryRepository;
        private readonly IRepository<Cart> cartRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<Screenshot> screenshotRepository;
        private readonly IRepository<Game> gameRepository;
        private readonly IGameService gameService;
        private readonly IUserService userService;
        private readonly IFileStorage fileStorage;

        public GameViewModelService(IUserService userService, IRepository<User> userRepository, IRepository<Libriary> libriaryRepository, IRepository<Cart> cartRepository, IFileStorage fileStorage, IRepository<Game> gameRepository, IGameService gameService, IRepository<Image> imageRepository, IRepository<Screenshot> screenshotRepository)
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.libriaryRepository = libriaryRepository;
            this.cartRepository = cartRepository;
            this.fileStorage = fileStorage;
            this.imageRepository = imageRepository;
            this.screenshotRepository = screenshotRepository;
            this.gameService = gameService;
            this.gameRepository = gameRepository;
        }

        public int Add(GameViewModel game)
        {
            game.IsApproved = false;
            game.Discont = 0;
            int id = gameService.Add(ConvertToModel(game));

            foreach (var file in game.Files)
            {
                gameService.AddScreenShot(file.OpenReadStream(), id);
            }
            return id;
        }

        public GameViewModel GetById(int id)
        {
            var game = gameService.Get(id);
            return game != null ? ConvertToModel(game) : null;
        }

        public StoreViewModel List()
        {
            Random random = new Random();
            var games = gameRepository.List().OrderBy(x => random.Next()).Select(ConvertToModel);
            var tenGames = games.Take(10).ToList();
            var elseGames = games.TakeLast(games.Count() - tenGames.Count()).ToList();
            return new StoreViewModel 
            { 
                TenGames = tenGames,
                ElseGames = elseGames
            };
        }

        public IEnumerable<GameViewModel> GetCart(int userId)
        {
            var cart = cartRepository.List(new CartSpecification(userId));
            var games = new List<GameViewModel>();
            foreach (var game in cart)
            {
                var screenshots = screenshotRepository.List(new ScreenshotSpecification(game.Game.Id));

                var images = new List<string>();

                images.AddRange(screenshots.Select(i => $"{i.Image.Name}{i.Image.Extension}"));

                games.Add(new GameViewModel
                {
                    Name = game.Game.Name,
                    Id = game.Game.Id,
                    Price = game.Game.Price,
                    Discont = game.Game.Discont,
                    Developer = game.Game.Developer,
                    IsApproved = game.Game.IsApproved,
                    DeveloperId = game.Game.DeveloperId,
                    Screenshots = images.ToArray()
                });
            }

            return games;
        }

        public ICollection<GameViewModel> SearchGame(string name)
        {
            return gameRepository.List(new GameByNameSpecification(name)).Select(ConvertToModel).ToList();
        }

        public void AddToCart(int userId, int gameId)
        {
            gameService.AddToCart(userId, gameId);
        }

        public void BuyFromCart(int userId)
        {
            var cart = cartRepository.List(new CartSpecification(userId));

            float price = GetCart(userId).Sum(p => p.Price);
            var user = userRepository.Get(userId);
            if (user.Balance < price)
            {
                return;
            }

            foreach (var game in cart)
            {
                gameService.AddToLibriary(game, userId);

                DeleteFromCart(userId, game.GameId);
            }

            user.Balance -= price;
            userService.Edit(user);
        }

        public void DeleteFromCart(int userId, int gameId)
        {
            gameService.DeleteFromCart(userId, gameId);
        }

        public ICollection<GameViewModel> GetLibriary(int userId)
        {
            var libriary = libriaryRepository.List(new LibriarySpecification(userId));
            var games = new List<GameViewModel>();
            foreach(var game in libriary)
            {
                var screenshots = screenshotRepository.List(new ScreenshotSpecification(game.Game.Id));

                var images = new List<string>();

                images.AddRange(screenshots.Select(i => $"{i.Image.Name}{i.Image.Extension}"));

                games.Add(new GameViewModel
                {
                    Name = game.Game.Name,
                    Id = game.Game.Id,
                    Price = game.Game.Price,
                    Discont = game.Game.Discont,
                    Developer = game.Game.Developer,
                    IsApproved = game.Game.IsApproved,
                    DeveloperId = game.Game.DeveloperId,
                    Screenshots = images.ToArray()
                });
            }

            return games;
        }

        public GameViewModel GetUnapprovedGame()
        {
            var game = gameRepository.List(new UnapprovedGameSpecification()).FirstOrDefault();
            if (game == null)
            {
                return null;
            }

            return ConvertToModel(game);
        }

        public ICollection<GameViewModel> GetGamesByDeveloper(int userId)
        {
            return gameRepository.List(new GamesByDeveloperSpecification(userId)).Select(ConvertToModel).ToList();
        }

        public void MakeDiscont(int gameId, float discont)
        {
            var game = gameRepository.Get(gameId);
            game.Discont = discont;
            gameService.Edit(game);
        }

        public void Approve(int gameId)
        {
            var game = gameRepository.Get(gameId);
            game.IsApproved = true;
            gameService.Edit(game);
        }

        public void NotApprove(int gameId)
        {
            var game = gameRepository.Get(gameId);

            var screenshots = screenshotRepository.List(new ScreenshotSpecification(gameId));
            foreach (var screenshot in screenshots)
            {
                var databaseImage = imageRepository.Get(screenshot.ImageId);
                gameService.DeleteScreenshot(databaseImage);
            }

            gameService.Delete(game);
        }

        private GameViewModel ConvertToModel(Game game)
        {
            if (game == null)
            {
                return null;
            }

            var screenshots = screenshotRepository.List(new ScreenshotSpecification(game.Id));

            var images = new List<string>();

            images.AddRange(screenshots.Select(i => $"{i.Image.Name}{i.Image.Extension}"));

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Discont = game.Discont,
                Developer = game.Developer,
                IsApproved = game.IsApproved,
                DeveloperId = game.DeveloperId,
                Screenshots = images.ToArray()
            };
        }

        private Game ConvertToModel(GameViewModel game)
        {
            return new Game
            {
                Id = game.Id.HasValue ? game.Id.Value : 0,
                Name = game.Name,
                Price = game.Price,
                Discont = game.Discont,
                Developer = game.Developer,
                IsApproved = game.IsApproved,
                DeveloperId = game.DeveloperId
            };
        }

    }
}