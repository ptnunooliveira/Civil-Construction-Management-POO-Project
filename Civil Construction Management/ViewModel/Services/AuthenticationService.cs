using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModel.Interfaces;

namespace Civil_Construction_Management.ViewModel.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserExists(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Arguments not defined.");

            User user = _userRepository.GetUserByUsername(username);

            if (user != null)
                return false;

            return user.Password == password;
        }

        public bool ValidUsername(string username)
        {

            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Argument not defined.");

            User user = _userRepository.GetUserByUsername(username);

            if (user == default)
                return false;

            return true;
        }

        public bool CreateUser(User user)
        {

            if(user == default)           
                throw new ArgumentException("Argument not defined.");

            _userRepository.AddUser(user);

            return true;
        }
    }
}
