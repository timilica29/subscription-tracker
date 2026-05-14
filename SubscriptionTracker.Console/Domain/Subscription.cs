using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class Subscription
    {
        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public DateTime DueDate { get; set; }
        public Price Price { get; set; }
        public User User { get; set; }
    }
}
