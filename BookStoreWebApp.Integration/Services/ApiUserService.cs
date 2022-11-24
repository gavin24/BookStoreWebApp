using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class ApiUserService : IApiUserService
    {
        private IApiUserRepository _iApiUserRepository;
        public ApiUserService(IApiUserRepository iApiUserRepository)
        {
            _iApiUserRepository = iApiUserRepository;
        }

        public void DeleteApiUser(long apiUserId)
        {
            _iApiUserRepository.DeleteApiUser(apiUserId);
            
        }

        public ApiUser GetApiUserByEmail(string email)
        {
            return _iApiUserRepository.GetApiUserByEmail(email);
        }

        public ApiUser GetApiUserByID(long apiUserId)
        {
            return _iApiUserRepository.GetApiUserByID(apiUserId);
        }

        public IEnumerable<ApiUser> GetApiUsers()
        {
            return _iApiUserRepository.GetApiUsers();
        }

        public void InsertApiUser(ApiUser apiUser)
        {
            _iApiUserRepository.InsertApiUser(apiUser);
        }

        public void Save()
        {
            _iApiUserRepository.Save();
        }

        public void UpdateApiUser(ApiUser apiUser)
        {
            _iApiUserRepository.UpdateApiUser(apiUser);
        }
    }
}
