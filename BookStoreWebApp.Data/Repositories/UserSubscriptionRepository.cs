using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class UserSubscriptionRepository : IUserSubscriptionRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public UserSubscriptionRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteUserSubscription(long userSubscriptionId)
        {
            UserSubscription userSubscription = context.UserSubscriptions.Find(userSubscriptionId);
            context.UserSubscriptions.Remove(userSubscription);
            context.SaveChanges();
        }

        public UserSubscription GetUserSubscriptionByID(long userSubscriptionId)
        {
            return context.UserSubscriptions.Find(userSubscriptionId);
        }

        public IEnumerable<UserSubscription> GetUserSubscriptions()
        {
            return context.UserSubscriptions.ToList();
        }
        public IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(long userId)
        {
            return context.UserSubscriptions.Where(x => x.UserId == userId).ToList();
        }
        public void InsertUserSubscription(UserSubscription userSubscription)
        {
            context.UserSubscriptions.Add(userSubscription);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateUserSubscription(UserSubscription userSubscription)
        {
            context.Entry(userSubscription).State = EntityState.Modified;
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
        // ~UserSubscriptionRepository()
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
