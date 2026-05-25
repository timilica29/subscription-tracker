namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class MonthlySubscription : Subscription
    {
        public MonthlySubscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price, string subscriptionPlan) : base(id, subscriptionType, dueDate, price, subscriptionPlan)
        {
        }
        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice;
        }
    }
}
