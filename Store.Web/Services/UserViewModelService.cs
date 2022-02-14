using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.Specifications;
using Store.Web.Interfaces;
using Store.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Services
{
    public class UserViewModelService : IUserViewModelService
    {
        private const string jpgExtension = ".jpg";

        private readonly IRepository<FriendRequest> friendRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<Member> roleRepository;
        private readonly IRepository<Avatar> avatarRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUserService userService;

        public UserViewModelService(IRepository<User> userRepository, IRepository<FriendRequest> friendRepository, IRepository<Image> imageRepository, IRepository<Avatar> avatarRepository, IUserService userService, IPasswordHasher passwordHasher, IRepository<Member> roleRepository)
        {
            this.userRepository = userRepository;
            this.friendRepository = friendRepository;
            this.imageRepository = imageRepository;
            this.avatarRepository = avatarRepository;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
            this.roleRepository = roleRepository;
        }

        public int Add(SignInViewModel signIn)
        {
            return userService.Add(ConvertToModel(signIn));
        }

        public bool IsLoginUnique(string login)
        {
            if (userService.IsLoginUnique(login) == null)
            {
                return true;
            }
            return false;
        }

        public void Edit(EditProfileViewModel userProfile, UserViewModel user)
        {
            if (userProfile.Nickname != null)
            {
                user.Nickname = userProfile.Nickname;
            }
            
            if (userProfile.File != null)
            {
                userService.EditAvatar(userProfile.File.OpenReadStream(), user.Id.Value);
            }

            userService.Edit(ConvertToModel(user));
        }

        public UserViewModel GetById(int value)
        {
            var user = userService.Get(value);

            return user != null ? ConvertToModel(user) : null;
        }

        public UserViewModel GetByName(string value)
        {
            var user = userService.Get(value);
            return user != null ? ConvertToModel(user) : null;
        }

        public FriendsViewModel GetFriends(int userId)
        {
            var friendsRequests = friendRepository.List(new FriendsRequestSpecification(userId));

            var friendsReq = userService.List()
                .Join(friendsRequests, i => i.Id, p => p.RequestedToId, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsReq)
            {
                var imageId = avatarRepository.List(new UserAvatarSpecification(user.Id.Value)).Max(i => i.ImageId);
                var userImage = imageRepository.Get(imageId);
                user.Avatar = userImage != null ? $"{userImage.Name}{userImage.Extension}" : "blank.jpg";
            }

            var friendsReceived = friendRepository.List(new FriendsReceiveSpecification(userId));

            var friendsRec = userService.List()
                .Join(friendsReceived, i => i.Id, p => p.RequestedById, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsRec)
            {
                var imageId = avatarRepository.List(new UserAvatarSpecification(user.Id.Value)).Max(i => i.ImageId);
                var userImage = imageRepository.Get(imageId);
                user.Avatar = userImage != null ? $"{userImage.Name}{userImage.Extension}" : "blank.jpg";
            }

            var friends = new FriendsViewModel
            {
                FriendsRecieved = friendsRec,
                FriendsRequested = friendsReq
            };

            return friends;

            
        }

        public void SendRequest(int userId, int secondUserId)
        {
            userService.SendRequest(userId, secondUserId);
        }

        public ICollection<UserViewModel> RequestedFriends(int userId)
        {
            var friendsReceived = friendRepository.List(new RequestedFriendsSpecification(userId));

            var friendsRec = userService.List()
                .Join(friendsReceived, i => i.Id, p => p.RequestedById, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsRec)
            {
                var imageId = avatarRepository.List(new UserAvatarSpecification(user.Id.Value)).Max(i => i.ImageId);
                var userImage = imageRepository.Get(imageId);
                user.Avatar = $"{userImage.Name}{userImage.Extension}";
            }

            return friendsRec;
        }

        public ICollection<UserViewModel> SearchFriend(string nickname)
        {
            return userRepository.List(new UserByNicknameSpecification(nickname)).Select(ConvertToModel).ToList();
        }

        public void AcceptRequest(int userId, int secondUserId)
        {
            userService.AcceptRequest(userId, secondUserId);
        }

        private UserViewModel ConvertToModel(User user)
        {
            var imageId = avatarRepository.List(new UserAvatarSpecification(user.Id)).Max(i => i.ImageId);
            var userImage = imageRepository.Get(imageId);

            return new UserViewModel
            {
                Id = user.Id,
                Login = user.Login,
                Nickname = user.Nickname,
                Password = user.Password,
                Salt = user.Salt,
                Balance = user.Balance,
                Avatar = $"{userImage.Name}{userImage.Extension}",
                RoleIds = roleRepository.List(new UserRolesSpecification(user.Id)).Select(i => i.RoleId).ToArray()
            };
        }

        private User ConvertToModel(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id.HasValue ? userViewModel.Id.Value : 0,
                Balance = userViewModel.Balance,
                Login = userViewModel.Login,
                Nickname = userViewModel.Nickname,
                Password = userViewModel.Password,
                Salt = userViewModel.Salt,
                Members = userViewModel.RoleIds.Select(id => new Member { RoleId = id }).ToList()
            };
        }

        private User ConvertToModel(SignInViewModel signIn)
        {
            var salt = passwordHasher.GenerateSalt();

            return new User
            {
                Id = 0,
                Login = signIn.Login,
                Nickname = signIn.Login,
                Balance = 0,
                Password = passwordHasher.Hash(signIn.Password, salt),
                Salt = salt,
                Members = new List<Member> { new Member { RoleId = 1} }
            };
        }
    }
}
