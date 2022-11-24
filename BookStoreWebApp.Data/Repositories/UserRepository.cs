using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public UserRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteUser(long userId)
        {
            User user = context.Users.Find(userId);
            context.Users.Remove(user);
        }

        public User GetUserByID(long userId)
        {
            return context.Users.Find(userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void InsertUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Entry(user).State = EntityState.Modified;
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
        // ~UserRepository()
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

        public User GetUserByEmail(string userId)
        {
            return context.Users.Where(x => x.EmailAddress == userId).FirstOrDefault();
        }
    }
}
