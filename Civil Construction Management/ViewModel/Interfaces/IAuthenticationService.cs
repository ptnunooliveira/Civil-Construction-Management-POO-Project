using Civil_Construction_Management.Models;

namespace Civil_Construction_Management.ViewModel.Interfaces
{
    public interface IAuthenticationService
    {
        bool UserExists(string username, string password);
        bool ValidUsername(string username);
        bool CreateUser(User user);
    }
}
