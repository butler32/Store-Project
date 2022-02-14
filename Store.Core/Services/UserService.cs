using Store.Core.Entities;
using Store.Core.Interfaces;
using Store.Core.Specifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public class UserService : IUserService
    {
        private readonly string jpgExtension = ".jpg";

        private readonly IRepository<User> userRepository;
        private readonly IRepository<FriendRequest> friendRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<Member> roleRepository;
        private readonly IRepository<Avatar> avatarRepository;
        private readonly IFileStorage fileStorage;

        public UserService(IRepository<User> userRepository, IRepository<FriendRequest> friendRepository, IRepository<Image> imageRepository, IRepository<Avatar> avatarRepository, IPasswordHasher passwordHasher, IRepository<Member> roleRepository, IFileStorage fileStorage)
        {
            this.userRepository = userRepository;
            this.friendRepository = friendRepository;
            this.imageRepository = imageRepository;
            this.avatarRepository = avatarRepository;
            this.passwordHasher = passwordHasher;
            this.roleRepository = roleRepository;
            this.fileStorage = fileStorage;
        }

        public int Add(User user)
        {
            userRepository.Add(user);

            avatarRepository.Add(new Avatar
            {
                UserId = user.Id,
                ImageId = 24
            });

            return user.Id;
        }

        public void AcceptRequest(int userId, int secondUserId)
        {
            var request = friendRepository.List(new AcceptRequestSpecification(userId, secondUserId)).FirstOrDefault();
            request.Status = Entities.Enums.FriendRequestStatus.Accepted;
            friendRepository.Update(request);
        }

        public string IsLoginUnique(string login)
        {
            return userRepository.List(new UserByLoginSpecification(login)).Select(l => l.Login).FirstOrDefault();
        }

        public void Edit(User user)
        {
            userRepository.Update(user);
        }

        public void EditAvatar(Stream stream, int userId)
        {
            string imgName = fileStorage.Create(stream, jpgExtension, "UserAvatar");
            var image = imageRepository.Add(new Image
            {
                Id = 0,
                Name = imgName,
                Extension = jpgExtension
            });
            avatarRepository.Add(new Avatar
            {
                UserId = userId,
                ImageId = image.Id
            });
        }

        public void SendRequest(int userId, int secondUserId)
        {
            friendRepository.Add(new FriendRequest
            {
                RequestedById = userId,
                RequestedToId = secondUserId,
                Status = Entities.Enums.FriendRequestStatus.NotAccepted
            });
        }

        public User Get(string name)
        {
            return userRepository.List(new UserByLoginSpecification(name)).FirstOrDefault();
        }

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public IList<User> List()
        {
            return userRepository.List();
        }
    }
}
