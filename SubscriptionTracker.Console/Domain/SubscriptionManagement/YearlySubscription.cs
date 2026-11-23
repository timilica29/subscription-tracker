namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public class YearlySubscription : Subscription
    {
        public YearlySubscription(int id, SubscriptionType subscriptionType, DateOnly startDate, Price price) : base(id, subscriptionType, startDate, price)
        {
        }

        public override string PlanName => "Yearly";
        public override int BillingPeriodInMonths => 12;

        public override decimal CalculateCost()
        {
            return Price.SubscriptionPrice / 12;
        }
    }
}
