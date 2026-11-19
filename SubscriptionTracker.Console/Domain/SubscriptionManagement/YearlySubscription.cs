namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class YearlySubscription : Subscription
    {
        public YearlySubscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price) : base(id, subscriptionType, dueDate, price)
        {
        }

        public override string PlanName => "Yearly";

        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice / 12;
        }
    }
}
