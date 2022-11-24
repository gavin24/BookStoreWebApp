using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class ApiRequestService : IApiRequestService
    {
        private IApiRequestRepository _iApiRequestRepository;
        public ApiRequestService(IApiRequestRepository iApiRequestRepository) 
        {
            _iApiRequestRepository = iApiRequestRepository;
        }
        public void DeleteApiRequest(long apiRequestId)
        {
            _iApiRequestRepository.DeleteApiRequest(apiRequestId);
           
        }

        public ApiRequest GetApiRequestByID(long apiRequestId)
        {
            return _iApiRequestRepository.GetApiRequestByID(apiRequestId);
            
        }

        public IEnumerable<ApiRequest> GetApiRequests()
        {
            return _iApiRequestRepository.GetApiRequests();
        }

        public void InsertApiRequest(ApiRequest apiRequest)
        {
            _iApiRequestRepository.InsertApiRequest(apiRequest);
        }

        public void Save()
        {
            _iApiRequestRepository.Save();
        }

        public void UpdateApiRequest(ApiRequest apiRequest)
        {
            _iApiRequestRepository.UpdateApiRequest(apiRequest);
        }
    }
}
