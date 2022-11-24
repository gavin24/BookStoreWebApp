using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Integration.IServices
{
    public interface IUserSubscriptionService
    {
        IEnumerable<UserSubscription> GetUserSubscriptions();
        IEnumerable<UserSubscription> GetUserSubscriptionsByUserId(long userId);
        UserSubscription GetUserSubscriptionByID(long userSubscriptionId);
        void InsertUserSubscription(UserSubscription userSubscription);
        void DeleteUserSubscription(long userSubscriptionId);
        void UpdateUserSubscription(UserSubscription userSubscription);
        void Save();
    }
}
