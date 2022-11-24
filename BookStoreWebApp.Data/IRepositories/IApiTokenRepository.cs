using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IApiTokenRepository : IDisposable
    {
        IEnumerable<ApiToken> GetApiTokens();
        ApiToken GetApiTokenByID(long apiTokenId);
        void InsertApiToken(ApiToken apiToken);
        void DeleteApiToken(long apiTokenId);
        void UpdateApiToken(ApiToken apiToken);
        void Save();
    }
}
