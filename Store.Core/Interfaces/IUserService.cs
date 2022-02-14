using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Interfaces
{
    public interface IUserService
    {
        int Add(User user);
        User Get(int id);
        User Get(string name);
        IList<User> List();
        void Edit(User user);
        string IsLoginUnique(string login);
        void EditAvatar(Stream stream, int userId);
        void SendRequest(int userId, int secondUserId);
        void AcceptRequest(int userId, int secondUserId);
    }
}
