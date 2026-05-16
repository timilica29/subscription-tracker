using SubscriptionTracker.ConsoleApp.Domain.Enums;

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

        public decimal CalculateTotalMonthlyCost() 
        {
            return Subscriptions.Sum(s => s.Price.SubscriptionPrice);
        }

        public bool CheckDuplicateSubscriptions(int subscriptionTypeId) 
        {
            return Subscriptions.Any(s => s.SubscriptionType.Id == subscriptionTypeId);
        }

        public void AddSubscription(Subscription subscription) 
        {
            var checkDuplicate = CheckDuplicateSubscriptions(subscription.SubscriptionType.Id);
            if (!checkDuplicate)
            {
                Subscriptions.Add(subscription);
            }
            else
            {
                Console.WriteLine("The subscription you are trying to add already exists!");
            }
        }
    }
}
