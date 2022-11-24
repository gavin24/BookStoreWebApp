using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IBookSubscriptionService
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
