using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class ApiTokenService : IApiTokenService
    {
        private IApiTokenRepository _iApiTokenRepository;
        public ApiTokenService(IApiTokenRepository iApiTokenRepository)
        {
            _iApiTokenRepository = iApiTokenRepository;
        }
        public void DeleteApiToken(long apiTokenId)
        {
            _iApiTokenRepository.DeleteApiToken(apiTokenId);
            
        }

        public ApiToken GetApiTokenByID(long apiTokenId)
        {
            return _iApiTokenRepository.GetApiTokenByID(apiTokenId);
        }

        public IEnumerable<ApiToken> GetApiTokens()
        {
            return _iApiTokenRepository.GetApiTokens();
        }

        public void InsertApiToken(ApiToken apiToken)
        {
            _iApiTokenRepository.UpdateApiToken(apiToken);
        }

        public void Save()
        {
            _iApiTokenRepository.Save();
        }

        public void UpdateApiToken(ApiToken apiToken)
        {
            _iApiTokenRepository.UpdateApiToken(apiToken);
        }
    }
}
