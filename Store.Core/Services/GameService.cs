using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> gameRepositury;

        public GameService(IRepository<Game> gameRepository)
        {
            this.gameRepositury = gameRepository;
        }

        public Game Get(int id)
        {
            var game = gameRepositury.Get(id);

            return game;
        }
    }
}
