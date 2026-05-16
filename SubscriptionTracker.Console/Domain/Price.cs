using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class Price
    {
        public Price(decimal subscriptionPrice) 
        {
            SubscriptionPrice = subscriptionPrice;
            Currency = Currency.RON;
        }

        public decimal SubscriptionPrice { get; set; }
        public Currency Currency { get; set; }
    }
}
