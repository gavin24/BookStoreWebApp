using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IApiRequestService
    {
        IEnumerable<ApiRequest> GetApiRequests();
        ApiRequest GetApiRequestByID(long apiRequestId);
        void InsertApiRequest(ApiRequest apiRequest);
        void DeleteApiRequest(long apiRequestId);
        void UpdateApiRequest(ApiRequest apiRequest);
        void Save();
    }
}
