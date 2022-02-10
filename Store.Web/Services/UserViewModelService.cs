using Store.Core.Entities;
using Store.Core.Interfaces;
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
        private readonly IUserService userService;
        private readonly IFileStorage fileStorage;

        public UserViewModelService(IRepository<FriendRequest> friendRepository, IRepository<Image> imageRepository, IRepository<Avatar> avatarRepository, IUserService userService, IPasswordHasher passwordHasher, IRepository<Member> roleRepository, IFileStorage fileStorage)
        {
            this.friendRepository = friendRepository;
            this.imageRepository = imageRepository;
            this.avatarRepository = avatarRepository;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
            this.roleRepository = roleRepository;
            this.fileStorage = fileStorage;
        }

        public int Add(SignInViewModel signIn)
        {
            var userId = userService.Add(ConvertToModel(signIn));

            avatarRepository.Add(new Avatar
            {
                UserId = userId,
                ImageId = 24
            });

            return userId;
        }

        public bool IsLoginUnique(string login)
        {
            return userService.List().Any(u => u.Login.Equals(login));
        }

        public void Edit(EditProfileViewModel userProfile, UserViewModel user)
        {
            if (userProfile.Nickname != null)
            {
                user.Nickname = userProfile.Nickname;
            }
            
            if (userProfile.File != null)
            {
                string imgName = fileStorage.Create(userProfile.File.OpenReadStream(), jpgExtension, "UserAvatar");
                user.File = userProfile.File;
                user.Avatar = imgName;
                imageRepository.Add(new Image
                {
                    Id = 0,
                    Name = imgName,
                    Extension = jpgExtension
                });
                avatarRepository.Add(new Avatar
                {
                    UserId = user.Id.Value,
                    ImageId = imageRepository.List().FirstOrDefault(n => n.Name == imgName).Id
                });
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
            var friendsRequests = friendRepository.List()
                .Where(i => i.RequestedById == userId)
                .Where(s => s.Status == Core.Entities.Enums.FriendRequestStatus.Accepted);

            var friendsReq = userService.List()
                .Join(friendsRequests, i => i.Id, p => p.RequestedToId, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsReq)
            {
                var imageId = avatarRepository.List().Where(i => i.UserId == user.Id).Max(i => i.ImageId);
                var userImage = imageRepository.Get(imageId);
                user.Avatar = userImage != null ? $"{userImage.Name}{userImage.Extension}" : "blank.jpg";
            }

            var friendsReceived = friendRepository.List()
                .Where(i => i.RequestedToId == userId)
                .Where(s => s.Status == Core.Entities.Enums.FriendRequestStatus.Accepted);

            var friendsRec = userService.List()
                .Join(friendsReceived, i => i.Id, p => p.RequestedById, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsRec)
            {
                var imageId = avatarRepository.List().Where(i => i.UserId == user.Id).Max(i => i.ImageId);
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
            friendRepository.Add(new FriendRequest
            {
                RequestedById = userId,
                RequestedToId = secondUserId,
                Status = Core.Entities.Enums.FriendRequestStatus.NotAccepted
            });
        }

        public ICollection<UserViewModel> RequestedFriends(int userId)
        {
            var friendsReceived = friendRepository.List()
                .Where(i => i.RequestedToId == userId)
                .Where(s => s.Status == Core.Entities.Enums.FriendRequestStatus.NotAccepted);

            var friendsRec = userService.List()
                .Join(friendsReceived, i => i.Id, p => p.RequestedById, (i, p) => new UserViewModel
                {
                    Id = i.Id,
                    Nickname = i.Nickname
                }).ToList();

            foreach (var user in friendsRec)
            {
                var imageId = avatarRepository.List().Where(i => i.UserId == user.Id).Max(i => i.ImageId);
                var userImage = imageRepository.Get(imageId);
                user.Avatar = $"{userImage.Name}{userImage.Extension}";
            }

            return friendsRec;
        }

        public ICollection<UserViewModel> SearchFriend(string nickname)
        {
            return userService.List().Where(i => i.Nickname == nickname).Select(ConvertToModel).ToList();
        }

        public void AcceptRequest(int userId, int secondUserId)
        {
            var request = friendRepository.List().FirstOrDefault(i => i.RequestedById == secondUserId && i.RequestedToId == userId);
            request.Status = Core.Entities.Enums.FriendRequestStatus.Accepted;
            friendRepository.Update(request);
        }

        private UserViewModel ConvertToModel(User user)
        {
            var imageId = avatarRepository.List().Where(i => i.UserId == user.Id).Max(i => i.ImageId);
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
                RoleIds = roleRepository.List().Where(i => i.UserId == user.Id).Select(i => i.RoleId).ToArray()
            };
        }

        private User ConvertToModel(UserViewModel userViewModel)
        {
            Image image = new Image();

            if (userViewModel.File != null)
            {
                image = new Image
                {
                    Stream = userViewModel.File.OpenReadStream(),
                    Extension = jpgExtension,
                    Name = userViewModel.Avatar
                };
            }

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
