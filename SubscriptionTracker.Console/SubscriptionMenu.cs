using SubscriptionTracker.ConsoleApp.Domain;

namespace SubscriptionTracker.ConsoleApp
{
    public class SubscriptionMenu
    {
        public static User User { get; set; }

        public static bool IsRunning { get; set; } = true;

        public static void InitializeApp()
        {
            User = new User(1, "Timi");
            do 
            {
                ShowMainMenu();
            } while (IsRunning);
        }

        public static void ShowMainMenu()
        {
            
            Console.Clear();
            Console.WriteLine($"Welcome {User.Name}!\n");

            Console.WriteLine("****** Subscriptions Menu ******\n");
            Console.WriteLine("1. View Subscriptions");
            Console.WriteLine("2. Add Subscription");
            Console.WriteLine("3. Remove Subscription");
            Console.WriteLine("4. Mark Subscription as Paid");
            Console.WriteLine("5. View Total Monthly Cost");
            Console.WriteLine("0. Exit the Subscription App.\n");

            Console.WriteLine("Your selection: ");

            string? userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    HandleViewSubscriptions();
                    break;
                case "2":
                    HandleAddSubscription();
                    break;
                case "3":
                    //HandleRemoveSubscription();
                    break;
                case "4":
                    //HandleMarkSubscriptionAsPaid();
                    break;
                case "5":
                    //HandleViewTotalMonthlyCost();
                    break;
                case "0":
                    Console.WriteLine("Application shutting down...\nPress any key to quit.");
                    IsRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection.\nPress any key to continue.");
                    Console.ReadKey();
                    break;
            }
        }

        private static void HandleViewSubscriptions() 
        {
            User.ViewSubscriptions();
            Console.ReadKey();
            Console.Clear();
        }

        private static void HandleAddSubscription() 
        {
            Console.WriteLine("Please add a Subscription Id: ");
            int subscriptionId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the name and ID of the Subscription Type you want to add ");
            Console.WriteLine("Subscription Type ID: ");
            int subscriptionTypeId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Subscription Type Name: ");
            string subscriptionTypeName = Console.ReadLine();

            Console.WriteLine("Enter the due date of the Subscription: ");
            DateTime dueDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter the Price of the Subscription: ");
            decimal subscriptionPrice = Convert.ToDecimal(Console.ReadLine());

            Subscription subscription = new Subscription(subscriptionId, new SubscriptionType(subscriptionTypeId, subscriptionTypeName), dueDate, new Price(subscriptionPrice));

            User.AddSubscription(subscription);
        }
    }
}
