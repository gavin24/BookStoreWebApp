using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(long userId);
        User GetUserByEmail(string userId);
        void InsertUser(User user);
        void DeleteUser(long userId);
        void UpdateUser(User user);
        void Save();
    }
}
