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

        public void ViewSubscriptions()
        {
            if (Subscriptions.Any())
            {
                foreach (var subscriptions in Subscriptions)
                {
                    Console.WriteLine(subscriptions);
                }
            }
            else 
            {
                Console.WriteLine("You don't have any subscriptions yet! Try adding a subscription first!");
            }
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

        public void DeleteSubscription(int subscriptionId) 
        {
            var subscription = Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);
            if (subscription != null)
            {
                Subscriptions.Remove(subscription);
            }
            else
            {
                Console.WriteLine("The subscription you are trying to delete does not exist!");
            }
        }


        public bool MarkAsPaid(int subscriptionId) 
        {
            var subscription = Subscriptions.FirstOrDefault(s => s.Id == subscriptionId);

            if (subscription != null && subscription.SubscriptionStatus == SubscriptionStatus.Unpaid)
            {
                subscription.SubscriptionStatus = SubscriptionStatus.Paid;
                return true;
            }

            return false;
        }
    }
}
