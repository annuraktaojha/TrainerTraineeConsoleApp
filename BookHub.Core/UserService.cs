using BookHub.Core.Entities;
using BookHub.Core.Repository;

namespace BookHub.Core
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(User user)
        {
            if (string.IsNullOrEmpty(user.Email) || user.Password.Length < 6)
                return false;

            _userRepository.Add(user);
            return true;
        }
        // Other methods..
    }
    // Other methods..
}
 