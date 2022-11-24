using BookStoreWebApp.Data.IRepositories;
using BookStoreWebApp.Data.Models;
using BookStoreWebApp.Integration.IServices;

namespace BookStoreWebApp.Integration.Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private IUserSubscriptionRepository _iUserSubscriptionRepository;
        public UserSubscriptionService(IUserSubscriptionRepository iUserSubscriptionRepository)
        {
            _iUserSubscriptionRepository = iUserSubscriptionRepository;
        }

        public void DeleteUserSubscription(long userSubscriptionId)
        {
            _iUserSubscriptionRepository.DeleteUserSubscription(userSubscriptionId);
        }

        public UserSubscription GetUserSubscriptionByID(long userSubscriptionId)
        {
            return _iUserSubscriptionRepository.GetUserSubscriptionByID(userSubscriptionId);
        }

        public IEnumerable<UserSubscription> GetUserSubscriptions()
        {
            return _iUserSubscriptionRepository.GetUserSubscriptions();
        }

        public IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(long userId)
        {
            //IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(long userId);
            return _iUserSubscriptionRepository.GetUserSubscriptionsByUserId(userId);
        }

        public void InsertUserSubscription(UserSubscription userSubscription)
        {
            _iUserSubscriptionRepository.InsertUserSubscription(userSubscription);
        }

        public void Save()
        {
            _iUserSubscriptionRepository.Save();
        }

        public void UpdateUserSubscription(UserSubscription userSubscription)
        {
            _iUserSubscriptionRepository.UpdateUserSubscription(userSubscription);  
        }
    }
}
