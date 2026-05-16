using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class Subscription
    {
        public Subscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price) 
        {
            Id = id;
            SubscriptionType = subscriptionType;
            SubscriptionStatus = SubscriptionStatus.Unpaid;
            DueDate = dueDate;
            Price = price;
        }

        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public DateTime DueDate { get; set; }
        public Price Price { get; set; }
    }
}
