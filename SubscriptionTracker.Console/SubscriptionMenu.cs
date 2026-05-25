using SubscriptionTracker.ConsoleApp.Domain;
using SubscriptionTracker.ConsoleApp.Domain.SubscriptionManagement;

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
            Console.WriteLine("3. Delete Subscription");
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
                    HandleDeleteSubscription();
                    break;
                case "4":
                    HandleMarkSubscriptionAsPaid();
                    break;
                case "5":
                    HandleViewTotalMonthlyCost();
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
            var userSubscriptions = User.Subscriptions;

            if (userSubscriptions.Any())
            {
                Console.WriteLine("Your Subscriptions: \n");
                foreach (var subscriptions in userSubscriptions)
                {
                    Console.WriteLine(subscriptions);
                    Console.WriteLine("---------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("You have no subscriptions currently! Please add a subscription first!");
            }
            Console.ReadKey();
        }

        private static void HandleAddSubscription()
        {
            Console.WriteLine("Enter the Subscription Name: ");
            string subscriptionTypeName = Console.ReadLine();

            Console.WriteLine("Enter the plan type of your Subscription (Monthly/Yearly): ");
            string subscriptionPlan = Console.ReadLine();

            Console.WriteLine("Enter the due date of the Subscription: ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine()).Date;

            Console.WriteLine("Enter the Price of the Subscription: ");
            decimal subscriptionPrice = Convert.ToDecimal(Console.ReadLine());

            int subscriptionId;
            int subscriptionTypeId;
            Subscription subscription = null;

            if (User.Subscriptions.Any())
            {
                subscriptionId = User.Subscriptions.Max(s => s.Id);
                subscriptionTypeId = User.Subscriptions.Max(s => s.SubscriptionType.Id);
                subscriptionId++;
                subscriptionTypeId++;
            }
            else
            {
                subscriptionId = 1;
                subscriptionTypeId = 1;
            }

            switch (subscriptionPlan) 
            {
                case "Monthly":
                    subscription = new MonthlySubscription(subscriptionId, new SubscriptionType(subscriptionTypeId, subscriptionTypeName), dueDate, new Price(subscriptionPrice), subscriptionPlan);
                    break;
                case "Yearly":
                    subscription = new YearlySubscription(subscriptionId, new SubscriptionType(subscriptionTypeId, subscriptionTypeName), dueDate, new Price(subscriptionPrice), subscriptionPlan);
                    break;
                default:
                    Console.WriteLine("Invalid subscription plan! Please add a subscription again!");
                    break;
            }

            if (subscription != null)
            {
                if (User.AddSubscription(subscription))
                {
                    Console.WriteLine($"Subscription {subscriptionTypeName} was added successfully!");
                }
                else
                {
                    Console.WriteLine($"Subscription {subscriptionTypeName} already exists! Please add another subscription!");
                }
            }
            Console.ReadKey();
        }

        private static void HandleDeleteSubscription()
        {
            Console.WriteLine("Please enter the ID of the Subscription you want to remove: ");
            int subscriptionId = Convert.ToInt32(Console.ReadLine());

            if (User.Subscriptions.Any(s => s.Id == subscriptionId))
            {
                Console.WriteLine($"Are you sure you want to delete the subscription with the {subscriptionId}?\nY/N");
                string? userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "Y":
                        User.DeleteSubscription(subscriptionId);
                        Console.WriteLine($"Subscription with the ID - {subscriptionId} was deleted successfully!");
                        break;
                    case "N":
                        Console.WriteLine("Delete operation cancelled!");
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Delete operation cancelled!");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Delete could not happen because you currently have no subscriptions with the ID - {subscriptionId}! ");
            }
            Console.ReadKey();
        }

        private static void HandleMarkSubscriptionAsPaid()
        {
            Console.WriteLine("Please enter the ID of the Subscription you want to mark as paid: ");
            int subscriptionId = Convert.ToInt32(Console.ReadLine());

            if (User.MarkAsPaid(subscriptionId))
            {
                Console.WriteLine($"Subscription with the ID - {subscriptionId} was marked as paid!");
            }
            else
            {
                Console.WriteLine($"Mark as paid operation could not happen because you currently have no subscriptions with the ID - {subscriptionId} or the subscription is already marked as paid! ");
            }

            Console.ReadKey();
        }

        private static void HandleViewTotalMonthlyCost()
        {
            decimal totalCost = User.CalculateTotalCost();

            if (User.Subscriptions.Any())
            {
                Console.WriteLine($"Your total monthly cost for all of the subscriptions is: {totalCost} RON.");
            }
            else
            {
                Console.WriteLine("You have no subscriptions to calculate!");
            }

            Console.ReadKey();
        }
    }
}
