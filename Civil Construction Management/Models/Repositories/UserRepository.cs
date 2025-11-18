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

            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);

            _usersFile = Path.Combine(_basePath, "users.json");

            if (!File.Exists(_usersFile))
                File.WriteAllText(_usersFile, "[]");
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

        public bool AddUser(User user)
        {

            if (user == default || user == null)
                throw new ArgumentException("Argument not valid.");

            var users = LoadUsers();
            users.Add(user);

            // Fazer DDL para escrever no ficheiro
            var options = new JsonSerializerOptions { WriteIndented = true };
            string userString = JsonSerializer.Serialize(users, options);
            File.WriteAllText(_usersFile, userString);

            return true;
        }
    }
}
