using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Interfaces;

namespace Civil_Construction_Management.ViewModels.Services
{
    /// <summary>
    /// Provides authentication-related operations such as verifying user credentials,
    /// checking username availability, and creating new users.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// Repository used to access stored user information.
        /// </param>
        public AuthenticationService(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }

        /// <summary>
        /// Checks if a user exists with the given username and password.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <returns>
        /// True if the user exists and the password matches; otherwise false.
        /// </returns>
        public bool UserExists(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentException("username or password can't be null");

            User user = _userRepository.GetUserByUsername(username);

            if (user == null)
                throw new ArgumentException("User doesn't exist");

            if (user.Password != password)
                throw new ArgumentException("Username or password incorrect");

            return user.Password == password;
        }

        /// <summary>
        /// Checks if a username is already in use.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>
        /// True if the username exists; otherwise false.
        /// </returns>
        private bool ValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username can't be null");

            User user = _userRepository.GetUserByUsername(username);

            if (user == default)
                return true;

            return false;
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>True if the user was successfully created.</returns>
        public bool CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentException("User can't be null");

            if (user.Password != user.PasswordConfirmation)
                throw new ArgumentException("The passwords must be the same");

            if (!ValidUsername(user.Username))
                throw new ArgumentException("Username already exists");

            if (user.Username.Length > 20)
                throw new ArgumentException("Username is too long. Must be 20 characters or less");

            if (user.Password.Length < 5)
                throw new ArgumentException("Password must be at least 5 characters long");

            return _userRepository.AddUser(user);
        }
    }
}