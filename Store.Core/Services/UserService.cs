using Store.Core.Entities;
using Store.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;

        public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public int Add(User user)
        {
            userRepository.Add(user);

            return user.Id;
        }

        public void Edit(User user)
        {
            userRepository.Update(user);
        }

        public User Get(string name)
        {
            var list = userRepository.List();
            return list.FirstOrDefault(l => l.Login == name);
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
