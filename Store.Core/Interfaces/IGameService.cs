using Store.Core.Entities;
using System.IO;

namespace Store.Core.Interfaces
{
    public interface IGameService
    {
        Game Get(int id);
        int Add(Game game);
        void AddToCart(int userId, int gameId);
        void DeleteFromCart(int userId, int gameId);
        void AddToLibriary(Cart cart, int userId);
        void Edit(Game game);
        void DeleteScreenshot(Image image);
        void Delete(Game game);
        void AddScreenShot(Stream stream, int id);
    }
}
