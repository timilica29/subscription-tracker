using SubscriptionTracker.ConsoleApp.Domain.Enums;

namespace SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement
{
    public abstract class Subscription
    {
        public Subscription(int id, SubscriptionType subscriptionType, DateTime dueDate, Price price, string subscriptionPlan) 
        {
            Id = id;
            SubscriptionType = subscriptionType;
            SubscriptionStatus = SubscriptionStatus.Unpaid;
            DueDate = dueDate;
            Price = price;
            SubscriptionPlan = subscriptionPlan;
        }

        public int Id { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public SubscriptionStatus SubscriptionStatus { get; set; }
        public DateTime DueDate { get; set; }
        public Price Price { get; set; }
        public string SubscriptionPlan { get; set; }

        public abstract decimal CalculateCost();

        public override string ToString()
        {
            return $"{Id}, Name: {SubscriptionType.Name}, Plan: {SubscriptionPlan}, Status: {SubscriptionStatus}, Due Date: {DueDate}, Price: {Price.SubscriptionPrice} {Price.Currency}";
        }
    }
}
