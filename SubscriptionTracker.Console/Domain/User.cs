using SubscriptionTracker.ConsoleApp.Domain.Enums;
using SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement;

namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class User
    {
        public User(int id, string name)
        {
            Id = id;
            Name = name;
            Subscriptions = new List<Subscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subscription> Subscriptions { get; set; }

        public decimal CalculateTotalCost() 
        {
            return Subscriptions.Sum(s => s.CalculateCost());
        }

        public bool CheckDuplicateSubscriptions(string subscriptionTypeName) 
        {
            return Subscriptions.Any(s => s.SubscriptionType.Name == subscriptionTypeName);
        }

        public bool AddSubscription(Subscription subscription) 
        {
            bool result = false;
            var checkDuplicate = CheckDuplicateSubscriptions(subscription.SubscriptionType.Name);
            if (!checkDuplicate)
            {
                Subscriptions.Add(subscription);
                result = true;
            }
            return result;
        }

        public bool DeleteSubscription(int subscriptionId) 
        {
            bool result = false;
            var subscription = Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
            if (subscription != null)
            {
                Subscriptions.Remove(subscription);
                result = true;
            }
            return result;
        }


        public bool MarkAsPaid(int subscriptionId) 
        {
            bool result = false;
            var subscription = Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

            if (subscription != null && subscription.SubscriptionStatus == SubscriptionStatus.Unpaid)
            {
                subscription.SubscriptionStatus = SubscriptionStatus.Paid;
                result = true;
            }

            return result;
        }
    }
}
