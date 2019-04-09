using System.Linq;
using Domain.Entities.Models;
using Domain.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        #region Members

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion

        public IQueryable<User> GetUsers()
        {
            return _userRepository.Get();
        }

        public User CreateUser(User user)
        {
            return _userRepository.Create(user);
        }

        public User UpdateUser(User user)
        {
            return _userRepository.Update(user);
        }
    }
}
