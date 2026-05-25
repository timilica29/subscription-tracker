namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class YearlySubscription : Subscription
    {
        public YearlySubscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price, string subscriptionPlan) : base(id, subscriptionType, dueDate, price, subscriptionPlan)
        {
        }
        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice * 12;
        }
    }
}
