using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class ApiRequestRepository : IApiRequestRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public ApiRequestRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteApiRequest(long apiRequestId)
        {
            ApiRequest apiRequest = context.ApiRequests.Find(apiRequestId);
            context.ApiRequests.Remove(apiRequest);
            context.SaveChanges();
        }

        public ApiRequest GetApiRequestByID(long apiRequestId)
        {
            return context.ApiRequests.Find(apiRequestId);
        }

        public IEnumerable<ApiRequest> GetApiRequests()
        {
            return context.ApiRequests.ToList();
        }

        public void InsertApiRequest(ApiRequest apiRequest)
        {
            context.ApiRequests.Add(apiRequest);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();

        }

        public void UpdateApiRequest(ApiRequest apiRequest)
        {
            context.Entry(apiRequest).State = EntityState.Modified;
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ApiRequestRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
