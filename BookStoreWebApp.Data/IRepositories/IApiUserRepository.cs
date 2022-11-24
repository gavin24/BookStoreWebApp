using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IApiUserRepository : IDisposable
    {
        IEnumerable<ApiUser> GetApiUsers();
        ApiUser GetApiUserByID(long apiUserId);
        ApiUser GetApiUserByEmail(string email);
        void InsertApiUser(ApiUser apiUser);
        void DeleteApiUser(long apiUserId);
        void UpdateApiUser(ApiUser apiUser);
        void Save();
    }
}
