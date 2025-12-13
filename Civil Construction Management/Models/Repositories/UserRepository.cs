using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    /// <summary>
    /// Repository responsible for handling user data, including retrieval 
    /// and creation of user accounts stored in a JSON file.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly string _usersFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        /// <summary>
        /// Initializes the repository, ensures the Data directory exists, 
        /// and creates the users.json file if it does not already exist.
        /// </summary>
        public UserRepository()
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _usersFile = Path.Combine(_basePath, "users.json");

            if (!File.Exists(_usersFile))
                File.WriteAllText(_usersFile, "[]");
        }

        /// <summary>
        /// Retrieves a user based on their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The corresponding User object, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when username is null.</exception>
        public User GetUserByUsername(string username)
        {

            if (username == null)
                throw new ArgumentException("Argument not valid.");

            List<User> users = x.ReadJson<User>(_usersFile);
            return users.FirstOrDefault(x => x.Username == username);
        }

        /// <summary>
        /// Adds a new user to the repository and stores it in the JSON file.
        /// </summary>
        /// <param name="user">The User object to add.</param>
        /// <returns>True if the user was added successfully; otherwise, False.</returns>
        /// <exception cref="ArgumentException">Thrown when the user argument is invalid.</exception>
        public bool AddUser(User user)
        {

            if (user == default || user == null)
                throw new ArgumentException("Argument not valid.");

            return x.AppendJson<User>(user, _usersFile);
        }
    }
}