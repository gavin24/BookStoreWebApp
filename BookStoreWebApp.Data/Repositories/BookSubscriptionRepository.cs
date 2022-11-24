using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.Repositories
{
    public class BookSubscriptionRepository : IBookSubscriptionRepository, IDisposable
    {
        private bool disposedValue;
        private BookStoreDbContext context;

        public BookSubscriptionRepository(BookStoreDbContext context)
        {
            this.context = context;
        }
        public void DeleteBookSubscription(long bookSubscriptionId)
        {
            BookSubscription bookSubscription = context.BookSubscriptions.Find(bookSubscriptionId);
            context.BookSubscriptions.Remove(bookSubscription);
            context.SaveChanges();
        }

        public BookSubscription GetBookSubscriptionByID(long bookSubscriptionId)
        {
            return context.BookSubscriptions.Find(bookSubscriptionId);
        }
        public IEnumerable<BookSubscription> GetBookSubscriptionsByBookId(long bookId)
        {
            return context.BookSubscriptions.Where(x => x.BookId == bookId).ToList();
        }
        public IEnumerable<BookSubscription> GetBookSubscriptions()
        {
            return context.BookSubscriptions.ToList();
        }

        public void InsertBookSubscription(BookSubscription bookSubscription)
        {
            context.BookSubscriptions.Add(bookSubscription);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateBookSubscription(BookSubscription bookSubscription)
        {
            context.Entry(bookSubscription).State = EntityState.Modified;
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
        // ~BookSubscriptionRepository()
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
