using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(long userId);
        User GetUserByEmail(string email);
        void InsertUser(User user);
        void DeleteUser(long userId);
        void UpdateUser(User user);
        void Save();
    }
}
