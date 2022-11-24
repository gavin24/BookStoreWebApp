using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class BookSubscriptionService : IBookSubscriptionService
    {
        private IBookSubscriptionRepository _iBookSubscriptionRepository;
        public BookSubscriptionService(IBookSubscriptionRepository iBookSubscriptionRepository)
        {
            _iBookSubscriptionRepository = iBookSubscriptionRepository;
        }

        public void DeleteBookSubscription(long bookSubscriptionId)
        {
            _iBookSubscriptionRepository.DeleteBookSubscription(bookSubscriptionId);
        }

        public BookSubscription GetBookSubscriptionByID(long bookSubscriptionId)
        {
           return _iBookSubscriptionRepository.GetBookSubscriptionByID(bookSubscriptionId);
        }

        public IEnumerable<BookSubscription> GetBookSubscriptions()
        {
            return _iBookSubscriptionRepository.GetBookSubscriptions();
        }
      
        public IEnumerable<BookSubscription> GetBookSubscriptionsByBookId(long bookId)
        {
            return _iBookSubscriptionRepository.GetBookSubscriptionsByBookId(bookId);
        }

        public void InsertBookSubscription(BookSubscription bookSubscription)
        {
            _iBookSubscriptionRepository.InsertBookSubscription(bookSubscription);
        }

        public void Save()
        {
            _iBookSubscriptionRepository.Save();
        }

        public void UpdateBookSubscription(BookSubscription bookSubscription)
        {
            _iBookSubscriptionRepository.UpdateBookSubscription(bookSubscription);
        }
    }
}
