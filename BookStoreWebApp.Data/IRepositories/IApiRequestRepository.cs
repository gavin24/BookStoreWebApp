using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IApiRequestRepository : IDisposable
    {
        IEnumerable<ApiRequest> GetApiRequests();
        ApiRequest GetApiRequestByID(long apiRequestId);
        void InsertApiRequest(ApiRequest apiRequest);
        void DeleteApiRequest(long apiRequestId);
        void UpdateApiRequest(ApiRequest apiRequest);
        void Save();
    }
}
