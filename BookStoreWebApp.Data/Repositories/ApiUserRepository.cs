using Microsoft.EntityFrameworkCore;
using System.Net;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class ApiUserRepository : IApiUserRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public ApiUserRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteApiUser(long apiUserId)
        {
            ApiUser apiUsers = context.ApiUsers.Find(apiUserId);
            context.ApiUsers.Remove(apiUsers);
            context.SaveChanges();
        }

        public ApiUser GetApiUserByID(long apiUserId)
        {
            return context.ApiUsers.Find(apiUserId);
        }
        public ApiUser GetApiUserByEmail(string email)
        {
            return context.ApiUsers.Where(x => x.EmailAddress == email).FirstOrDefault();
            
        }
        public IEnumerable<ApiUser> GetApiUsers()
        {
            return context.ApiUsers.ToList();
        }

        public void InsertApiUser(ApiUser apiUser)
        {
            context.ApiUsers.Add(apiUser);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateApiUser(ApiUser apiUser)
        {
            context.Entry(apiUser).State = EntityState.Modified;
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
        // ~ApiUserRepository()
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
