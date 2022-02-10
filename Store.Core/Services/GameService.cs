using Store.Core.Entities;
using Store.Core.Interfaces;

namespace Store.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepositury;

        public GameService(IRepository<Game> gameRepository)
        {
            this.gameRepositury = gameRepository;
        }

        public int Add(Game game)
        {
            gameRepositury.Add(game);

            return game.Id;
        }

        public Game Get(int id)
        {
            var game = gameRepositury.Get(id);

            return game;
        }
    }
}
