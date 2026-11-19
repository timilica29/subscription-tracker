namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class MonthlySubscription : Subscription
    {
        public MonthlySubscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price) : base(id, subscriptionType, dueDate, price)
        {
        }

        public override string PlanName => "Monthly";

        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice;
        }
    }
}
