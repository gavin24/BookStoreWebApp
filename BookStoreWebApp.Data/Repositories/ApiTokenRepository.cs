using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class ApiTokenRepository : IApiTokenRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public ApiTokenRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteApiToken(long apiTokenId)
        {
            ApiToken apiToken = context.ApiTokens.Find(apiTokenId);
            context.ApiTokens.Remove(apiToken);
            context.SaveChanges();
        }

        public ApiToken GetApiTokenByID(long apiTokenId)
        {
            return context.ApiTokens.Find(apiTokenId);
        }

        public IEnumerable<ApiToken> GetApiTokens()
        {
            return context.ApiTokens.ToList();
        }

        public void InsertApiToken(ApiToken apiToken)
        {
            context.ApiTokens.Add(apiToken);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateApiToken(ApiToken apiToken)
        {
            context.Entry(apiToken).State = EntityState.Modified;
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
        // ~ApiTokenRepository()
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
