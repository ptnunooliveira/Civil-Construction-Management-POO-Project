namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    /// <summary>
    /// Interface that defines the contract for accessing and managing user information.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves a user based on their username.
        /// </summary>
        /// <param name="username">The unique username of the user.</param>
        /// <returns>The corresponding User object, or null if not found.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        /// <returns>True if the user was added successfully; otherwise, False.</returns>
        bool AddUser(User user);
    }
}