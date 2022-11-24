using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IUserLoginService
    {
        IEnumerable<UserLogin> GetUserLogins();
        UserLogin GetUserLogintByID(long userLoginId);
        void InsertUserLogin(UserLogin userLogin);
        void DeleteUserLogin(long userLoginId);
        void UpdateUserLogin(UserLogin userLogin);
        void Save();
    }
}
