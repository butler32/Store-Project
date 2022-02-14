using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.Specifications;
using System.IO;
using System.Linq;

namespace Store.Core.Services
{
    public class GameService : IGameService
    {
        private const string jpgExtension = ".jpg";

        private readonly IRepository<User> userRepository;
        private readonly IRepository<Libriary> libriaryRepository;
        private readonly IRepository<Cart> cartRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<Screenshot> screenshotRepository;
        private readonly IRepository<Game> gameRepository;
        private readonly IFileStorage fileStorage;

        public GameService(IRepository<Game> gameRepository, IRepository<User> userRepository, IRepository<Libriary> libriaryRepository, IRepository<Cart> cartRepository, IFileStorage fileStorage, IRepository<Image> imageRepository, IRepository<Screenshot> screenshotRepository)
        {
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
            this.libriaryRepository = libriaryRepository;
            this.cartRepository = cartRepository;
            this.fileStorage = fileStorage;
            this.imageRepository = imageRepository;
            this.screenshotRepository = screenshotRepository;
        }

        public int Add(Game game)
        {
            gameRepository.Add(game);

            return game.Id;
        }

        public void AddScreenShot(Stream stream, int id)
        {
            string imgName = fileStorage.Create(stream, jpgExtension, "GameImages");
            imageRepository.Add(new Image
            {
                Id = 0,
                Name = imgName,
                Extension = jpgExtension
            });

            screenshotRepository.Add(new Screenshot
            {
                GameId = id,
                ImageId = imageRepository.List(new ImageByNameSpecification(imgName)).FirstOrDefault().Id
            });
        }

        public Game Get(int id)
        {
            var game = gameRepository.Get(id);

            return game;
        }

        public void DeleteScreenshot(Image image)
        {
            fileStorage.Delete(image.Name, image.Extension, "GameImages");
            imageRepository.Delete(image);
        }

        public void Delete(Game game)
        {
            gameRepository.Delete(game);
        }

        public void AddToCart(int userId, int gameId)
        {
            cartRepository.Add(new Cart
            {
                GameId = gameId,
                UserId = userId
            });
        }

        public void DeleteFromCart(int userId, int gameId)
        {
            cartRepository.Delete(new Cart
            {
                UserId = userId,
                GameId = gameId
            });
        }

        public void AddToLibriary(Cart cart, int userId)
        {
            libriaryRepository.Add(new Libriary
            {
                UserId = userId,
                GameId = cart.GameId
            });
        }

        public void Edit(Game game)
        {
            gameRepository.Update(game);
        }
    }
}
