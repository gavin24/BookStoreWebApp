using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IUserLoginRepository : IDisposable
    {
        IEnumerable<UserLogin> GetUserLogins();
        UserLogin GetUserLogintByID(long userLoginId);
        void InsertUserLogin(UserLogin userLogin);
        void DeleteUserLogin(long userLoginId);
        void UpdateUserLogin(UserLogin userLogin);
        void Save();
    }
}
