using Civil_Construction_Management.Models.Repositories.Interfaces;
using DLL___Project_Support;
using System.IO;

namespace Civil_Construction_Management.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _usersFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        private readonly VerifyRepositories x = new VerifyRepositories();

        public UserRepository()
        {

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _usersFile = Path.Combine(_basePath, "users.json");

            if (!File.Exists(_usersFile))
                File.WriteAllText(_usersFile, "[]");
        }
               

        public User GetUserByUsername(string username)
        {

            if (username == null)
                throw new ArgumentException("Argument not valid.");

            List<User> users = x.ReadJson<User>(_usersFile);
            return users.FirstOrDefault(x => x.Username == username);
        }

        public bool AddUser(User user)
        {

            if (user == default || user == null)
                throw new ArgumentException("Argument not valid.");

            return x.AppendJson<User>(user, _usersFile);
        }      
    }
}
