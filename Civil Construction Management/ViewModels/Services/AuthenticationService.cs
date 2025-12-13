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
        /// <exception cref="ArgumentNullException">
        /// Thrown when the username or password is null or empty.
        /// </exception>
        public bool UserExists(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new ArgumentNullException("Arguments not defined.");

            User user = _userRepository.GetUserByUsername(username);

            if (user == null)
                return false;

            return user.Password == password;
        }

        /// <summary>
        /// Checks if a username is already in use.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>
        /// True if the username exists; otherwise false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the username is null or empty.
        /// </exception>
        public bool ValidUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Argument not defined.");

            User user = _userRepository.GetUserByUsername(username);

            if (user == default)
                return false;

            return true;
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>True if the user was successfully created.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the provided user object is null.
        /// </exception>
        public bool CreateUser(User user)
        {
            if (user == default)
                throw new ArgumentException("Argument not defined.");

            _userRepository.AddUser(user);

            return true;
        }
    }
}