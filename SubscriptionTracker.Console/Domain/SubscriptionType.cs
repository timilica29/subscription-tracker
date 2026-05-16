namespace SubscriptionTracker.ConsoleApp.Domain
{
    public class SubscriptionType
    {
        public SubscriptionType(int id, string name) 
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
