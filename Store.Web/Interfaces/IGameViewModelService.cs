using Store.Core.Entities;
using Store.Web.Models;
using System.Collections.Generic;

namespace Store.Web.Interfaces
{
    public interface IGameViewModelService
    {
        GameViewModel GetById(int id);
        StoreViewModel List();
        int Add(GameViewModel game);
        IEnumerable<GameViewModel> GetCart(int userId);
        void AddToCart(int userId, int gameId);
        void DeleteFromCart(int userId, int gameId);
        void BuyFromCart(int userId);
        ICollection<GameViewModel> GetLibriary(int userId);
        GameViewModel GetUnapprovedGame();
        void Approve(int gameId);
        void NotApprove(int gameId);
        ICollection<GameViewModel> GetGamesByDeveloper(int userId);
        void MakeDiscont(int gameId, float discont);
        ICollection<GameViewModel> SearchGame (string name);
    }
}
