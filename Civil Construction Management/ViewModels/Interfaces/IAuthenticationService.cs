using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    /// <summary>
    /// Provides authentication functionalities such as verifying credentials,
    /// validating usernames, and creating new user accounts.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Checks whether a user exists with the specified username and password.
        /// </summary>
        /// <param name="username">The username to verify.</param>
        /// <param name="password">The password to verify.</param>
        /// <returns>True if the user exists and credentials match; otherwise, false.</returns>
        bool UserExists(string username, string password);

        /// <summary>
        /// Validates whether the provided username meets application rules 
        /// and is eligible for account creation.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        /// <returns>True if the username is valid; otherwise, false.</returns>
        bool ValidUsername(string username);

        /// <summary>
        /// Creates a new user and stores the account data in the repository.
        /// </summary>
        /// <param name="user">The user object representing the new account.</param>
        /// <returns>True if the user was successfully created; otherwise, false.</returns>
        bool CreateUser(User user);
    }
}