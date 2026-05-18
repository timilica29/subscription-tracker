using SubscriptionTracker.ConsoleApp.Domain;

namespace SubscriptionTracker.ConsoleApp
{
    public class SubscriptionMenu
    {
        public static User User { get; set; }
        public static void InitializeApp()
        {
            while (true) 
            {
                ShowMainMenu();
            }
        }

        public static void ShowMainMenu()
        {
            var myUser = new User(1, "Timi");
            Console.WriteLine($"Welcome {myUser.Name}!\n");

            Console.WriteLine("****** Subscriptions Menu ******\n");
            Console.WriteLine("1. View Subscriptions");
            Console.WriteLine("2. Add Subscription");
            Console.WriteLine("3. Remove Subscription");
            Console.WriteLine("4. Mark Subscription as Paid");
            Console.WriteLine("5. View Total Monthly Cost");
            Console.WriteLine("6. Exit the Subscription App.\n");

            Console.WriteLine("Choose one option from the menu to navigate through the app:");

            var userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    myUser.ViewSubscriptions();
                    break;
                case "2":
                    Console.WriteLine("Please add a Subscription Id: ");
                    var subscriptionId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Please enter the name and ID of the Subscription Type you want to add ");
                    Console.WriteLine("Subscription Type ID: ");
                    var subscriptionTypeId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Subscription Type Name: ");
                    var subscriptionTypeName = Console.ReadLine();

                    Console.WriteLine("Enter the due date of the Subscription: ");
                    var dueDate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Enter the Price of the Subscription: ");
                    var subscriptionPrice = Convert.ToDecimal(Console.ReadLine());

                    var subscription = new Subscription(subscriptionId, new SubscriptionType(subscriptionTypeId, subscriptionTypeName), dueDate, new Price(subscriptionPrice));

                    myUser.AddSubscription(subscription);
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }
    }
}
