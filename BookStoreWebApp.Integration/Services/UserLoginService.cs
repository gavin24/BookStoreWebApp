using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class UserLoginService : IUserLoginService
    {
        private IUserLoginRepository _iUserLoginRepository;
        public UserLoginService(IUserLoginRepository iUserLoginRepository)
        {
            _iUserLoginRepository = iUserLoginRepository;
        }

        public void DeleteUserLogin(long userLoginId)
        {
            _iUserLoginRepository.DeleteUserLogin(userLoginId);
        }

        public IEnumerable<UserLogin> GetUserLogins()
        {
            return _iUserLoginRepository.GetUserLogins();
        }

        public UserLogin GetUserLogintByID(long userLoginId)
        {
           return _iUserLoginRepository.GetUserLogintByID(userLoginId);
        }

        public void InsertUserLogin(UserLogin userLogin)
        {
            _iUserLoginRepository.InsertUserLogin(userLogin);
        }

        public void Save()
        {
            _iUserLoginRepository.Save();
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            _iUserLoginRepository.UpdateUserLogin(userLogin);   
        }
    }
}
