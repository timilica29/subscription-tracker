using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public abstract class Subscription
    {
        public Subscription(int id, SubscriptionType subscriptionType, DateOnly startDate, Price price) 
        {
            Id = id;
            SubscriptionType = subscriptionType;
            SubscriptionStatus = SubscriptionStatus.Unpaid;
            StartDate = startDate;
            Price = price;
        }

        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public DateOnly StartDate { get; set; }
        public Price Price { get; set; }
        public abstract string PlanName { get; }
        public abstract int BillingPeriodInMonths { get; }

        public abstract decimal CalculateCost();

        public DateOnly CalculateNextBillingDate(DateOnly today)
        {
            
            int counter = 0;
            DateOnly billingDate = StartDate.AddMonths(counter * BillingPeriodInMonths);

            while (billingDate < today)
            {
                counter++;
                billingDate = StartDate.AddMonths(counter * BillingPeriodInMonths);
            }

            return billingDate;
        }

        public override string ToString()
        {
            return $"{Id}, Name: {SubscriptionType.Name}, Plan: {PlanName}, Status: {SubscriptionStatus}, Start Date: {StartDate}, Price: {Price.SubscriptionPrice} {Price.Currency}";
        }
    }
}
