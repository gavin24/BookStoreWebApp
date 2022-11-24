using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _iUserRepository;
        public UserService(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public void DeleteUser(long userId)
        {
            _iUserRepository.DeleteUser(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _iUserRepository.GetUserByEmail(email);
        }

        public User GetUserByID(long userId)
        {
            return _iUserRepository.GetUserByID(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _iUserRepository.GetUsers();
        }

        public void InsertUser(User user)
        {
            _iUserRepository.InsertUser(user);
        }

        public void Save()
        {
            _iUserRepository.Save();
        }

        public void UpdateUser(User user)
        {
            _iUserRepository.UpdateUser(user);
        }
    }
}
