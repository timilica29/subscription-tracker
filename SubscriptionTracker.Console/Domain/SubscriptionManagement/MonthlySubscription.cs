namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class MonthlySubscription : Subscription
    {
        public MonthlySubscription(int id, SubscriptionType subscriptionType, DateOnly startDate, Price price) : base(id, subscriptionType, startDate, price)
        {
        }

        public override string PlanName => "Monthly";
        public override int BillingPeriodInMonths => 1;

        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice;
        }
    }
}
