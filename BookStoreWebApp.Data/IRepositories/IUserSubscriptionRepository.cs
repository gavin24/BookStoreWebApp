using BookStoreWebApp.Data.Models;

namespace BookStoreWebApp.Data.IRepositories
{
    public interface IUserSubscriptionRepository : IDisposable
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
