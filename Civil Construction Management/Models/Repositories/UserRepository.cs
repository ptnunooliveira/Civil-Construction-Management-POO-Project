using Civil_Construction_Management.Models.Repositories.Interfaces;
using System.IO;
using System.Text.Json;

namespace Civil_Construction_Management.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _usersFile;
        private string _basePath = Path.Combine("." + Path.DirectorySeparatorChar, "Data");

        public UserRepository()
        {

            _usersFile = Path.Combine(_basePath, "users.json");
        }

        private List<User> LoadUsers()
        {

            string readJsonString = File.ReadAllText(_usersFile);
            return JsonSerializer.Deserialize<List<User>>(readJsonString);
        }

        public User GetUserByUsername(string username)
        {

            List<User> users = LoadUsers();
            return users.FirstOrDefault(x => x.Username == username);
        }
    }
}
