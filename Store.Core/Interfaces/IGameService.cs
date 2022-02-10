using Store.Core.Entities;

namespace Store.Core.Interfaces
{
    public interface IGameService
    {
        Game Get(int id);
        int Add(Game game);
    }
}
