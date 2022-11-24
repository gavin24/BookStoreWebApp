using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IApiTokenService
    {
        IEnumerable<ApiToken> GetApiTokens();
        ApiToken GetApiTokenByID(long apiTokenId);
        void InsertApiToken(ApiToken apiToken);
        void DeleteApiToken(long apiTokenId);
        void UpdateApiToken(ApiToken apiToken);
        void Save();
    }
}
