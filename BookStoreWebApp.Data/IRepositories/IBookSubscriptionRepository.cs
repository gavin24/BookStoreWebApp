using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IBookSubscriptionRepository : IDisposable
    {
        IEnumerable<BookSubscription> GetBookSubscriptions();
        IEnumerable<BookSubscription> GetBookSubscriptionsByBookId(long bookId);
        BookSubscription GetBookSubscriptionByID(long bookSubscriptionId);
        void InsertBookSubscription(BookSubscription bookSubscription);
        void DeleteBookSubscription(long bookSubscriptionId);
        void UpdateBookSubscription(BookSubscription bookSubscription);
        void Save();
    }
}
