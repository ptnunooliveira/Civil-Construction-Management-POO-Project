namespace Civil_Construction_Management.Models.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        bool AddUser(User user);
    }
}
