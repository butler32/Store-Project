using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Web.Interfaces;
using Store.Web.Models;
using System;
using System.Collections.Generic;
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
        private readonly IFileStorage fileStorage;

        public GameViewModelService(IRepository<User> userRepository, IRepository<Libriary> libriaryRepository, IRepository<Cart> cartRepository, IFileStorage fileStorage, IRepository<Game> gameRepository, IGameService gameService, IRepository<Image> imageRepository, IRepository<Screenshot> screenshotRepository)
        {
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
                string imgName = fileStorage.Create(file.OpenReadStream(), jpgExtension, "GameImages");
                imageRepository.Add(new Image
                {
                    Id = 0,
                    Name = imgName,
                    Extension = jpgExtension
                });

                screenshotRepository.Add(new Screenshot
                {
                    GameId = id,
                    ImageId = imageRepository.List().FirstOrDefault(n => n.Name == imgName).Id
                });
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
            var cart = cartRepository.List().Where(i => i.UserId == userId);
            var games = gameRepository.List()
                .Join(cart, i => i.Id, p => p.GameId, (i, p) => new GameViewModel
                {
                    Name = i.Name,
                    Id = i.Id,
                    Price = i.Price,
                    Discont = i.Discont,
                    Developer = i.Developer,
                    IsApproved = i.IsApproved,
                    DeveloperId = i.DeveloperId
                }).ToList();

            foreach (var game in games)
            {
                var imagesId = screenshotRepository.List().Where(i => i.GameId == game.Id);
                var images = imageRepository.List()
                    .Join(imagesId, i => i.Id, p => p.ImageId, (i, p) => new { Name = i.Name + i.Extension })
                    .Select(n => n.Name)
                    .ToArray();
                game.Screenshots = images;
            }

            return games;
        }

        public ICollection<GameViewModel> SearchGame(string name)
        {
            return gameRepository.List().Where(n => n.Name == name).Select(ConvertToModel).ToList();
        }

        public void AddToCart(int userId, int gameId)
        {
            cartRepository.Add(new Cart
            {
                GameId = gameId,
                UserId = userId
            });
        }

        public void BuyFromCart(int userId)
        {
            var cart = cartRepository.List().Where(i => i.UserId == userId);

            float price = GetCart(userId).Sum(p => p.Price);
            var user = userRepository.List().FirstOrDefault(i => i.Id == userId);
            if (user.Balance < price)
            {
                return;
            }

            foreach (var game in cart)
            {
                libriaryRepository.Add(new Libriary
                {
                    UserId = userId,
                    GameId = game.GameId
                });

                DeleteFromCart(userId, game.GameId);
            }

            user.Balance -= price;
            userRepository.Update(user);
        }

        public void DeleteFromCart(int userId, int gameId)
        {
            cartRepository.Delete(new Cart
            {
                UserId = userId,
                GameId = gameId
            });
        }

        public ICollection<GameViewModel> GetLibriary(int userId)
        {
            var libriary = libriaryRepository.List().Where(i => i.UserId == userId);
            var games = gameRepository.List()
                .Join(libriary, i => i.Id, p => p.GameId, (i, p) => new GameViewModel
                {
                    Name = i.Name,
                    Id = i.Id,
                    Price = i.Price,
                    Discont = i.Discont,
                    Developer = i.Developer,
                    IsApproved = i.IsApproved,
                    DeveloperId = i.DeveloperId
                }).ToList();

            foreach (var game in games)
            {
                var imagesId = screenshotRepository.List().Where(i => i.GameId == game.Id);
                var images = imageRepository.List()
                    .Join(imagesId, i => i.Id, p => p.ImageId, (i, p) => new { Name = i.Name + i.Extension })
                    .Select(n => n.Name)
                    .ToArray();
                game.Screenshots = images;
            }

            return games;
        }

        public GameViewModel GetUnapprovedGame()
        {
            var game = gameRepository.List().FirstOrDefault(b => b.IsApproved == false);
            if (game == null)
            {
                return null;
            }

            return ConvertToModel(game);
        }

        public ICollection<GameViewModel> GetGamesByDeveloper(int userId)
        {
            return gameRepository.List().Where(i => i.DeveloperId == userId).Select(ConvertToModel).ToList();
        }

        public void MakeDiscont(int gameId, float discont)
        {
            var game = gameRepository.List().FirstOrDefault(i => i.Id == gameId);
            game.Discont = discont;
            gameRepository.Update(game);
        }

        public void Approve(int gameId)
        {
            var game = gameRepository.List().FirstOrDefault(i => i.Id == gameId);
            game.IsApproved = true;
            gameRepository.Update(game);
        }

        public void NotApprove(int gameId)
        {
            var game = gameRepository.List().FirstOrDefault(i => i.Id == gameId);

            var screenshots = screenshotRepository.List().Where(i => i.GameId == game.Id);
            var images = imageRepository.List()
                .Join(screenshots, i => i.Id, p => p.ImageId, (i, p) => new { Name = i.Name, Extension = i.Extension });

            foreach (var image in images)
            {
                fileStorage.Delete(image.Name, image.Extension, "GameImages");
            }

            foreach (var screenshot in screenshots)
            {
                var databaseImage = imageRepository.List().FirstOrDefault(i => i.Id == screenshot.ImageId);
                imageRepository.Delete(databaseImage);
            }

            gameRepository.Delete(game);
        }

        private GameViewModel ConvertToModel(Game game)
        {
            if (game == null)
            {
                return null;
            }

            var imagesId = screenshotRepository.List().Where(i => i.GameId == game.Id);
            var images = imageRepository.List()
                .Join(imagesId, i => i.Id, p => p.ImageId, (i, p) => new { Name = i.Name + i.Extension })
                .Select(n => n.Name)
                .ToArray();

            return new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Price = game.Price,
                Discont = game.Discont,
                Developer = game.Developer,
                IsApproved = game.IsApproved,
                DeveloperId = game.DeveloperId,
                Screenshots = images
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