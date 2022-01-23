using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Interfaces
{
    public interface IGameViewModelService
    {
        GameViewModel GetById(int id);
        IEnumerable<GameViewModel> GetTen();
    }
}
