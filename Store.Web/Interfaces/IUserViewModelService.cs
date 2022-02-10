using Store.Core.Entities;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Interfaces
{
    public interface IUserViewModelService
    {
        int Add(SignInViewModel signIn);
        UserViewModel GetById(int value);
        UserViewModel GetByName(string value);
        void Edit(EditProfileViewModel editProfile, UserViewModel user);
        bool IsLoginUnique(string login);
        FriendsViewModel GetFriends(int userId);
        void SendRequest(int userId, int secondUserId);
        void AcceptRequest(int userId, int secondUserId);
        ICollection<UserViewModel> RequestedFriends(int userId);
        ICollection<UserViewModel> SearchFriend(string nickname);
    }
}
