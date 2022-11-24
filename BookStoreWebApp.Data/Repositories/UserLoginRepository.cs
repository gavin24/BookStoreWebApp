using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class UserLoginRepository : IUserLoginRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public UserLoginRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteUserLogin(long userLoginId)
        {
            UserLogin userLogin = context.UserLogins.Find(userLoginId);
            context.UserLogins.Remove(userLogin);
        }

        public IEnumerable<UserLogin> GetUserLogins()
        {
            return context.UserLogins.ToList();
        }

        public UserLogin GetUserLogintByID(long userLoginId)
        {
            return context.UserLogins.Find(userLoginId);
        }

        public void InsertUserLogin(UserLogin userLogin)
        {
            context.UserLogins.Add(userLogin);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUserLogin(UserLogin userLogin)
        {
            context.Entry(userLogin).State = EntityState.Modified;
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
        // ~UserLoginRepository()
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
