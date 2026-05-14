using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class Price
    {
        public decimal SubscriptionPrice { get; set; }
        public Currency Currency { get; set; }
    }
}
