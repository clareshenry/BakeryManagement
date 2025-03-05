using BakeryManagement.Application.Utils;
using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Application.Services
{
    public class BakeryService
    {
        private readonly List<BakeryOffice> _bakeryOffices = new List<BakeryOffice>();
        private readonly BreadService _breadService = new BreadService(new RecipePrinterService());

        // private readonly BakeryOffice mainBakeryOffice;
        // private readonly BakeryOffice secondaryBakeryOffice;

        public BakeryService()
        {
            var menuMainOffice = new List<Bread>()
            {
                new Baguette(),
                new WhiteBread(),
                new MilkBread(),
            };
            var menuSecondaryOffice = new List<Bread>()
            {
                new Baguette(),
                new WhiteBread(),
                new HamburguerBun(),
            };
            var mainBakeryOffice = new BakeryOffice("Main Office", 150, menuMainOffice);
            var secondaryBakeryOffice = new BakeryOffice(
                "Secondary Office",
                100,
                menuSecondaryOffice
            );

            _bakeryOffices.Add(mainBakeryOffice);
            _bakeryOffices.Add(secondaryBakeryOffice);
        }

        public void PrintOptionMenu()
        {
            var mainMenuOptions = new OptionManagerService();
            Console.WriteLine("Bakery Fresh Bread");
            Console.WriteLine("--------------------------------------------");
            for (int i = 0; i < _bakeryOffices.Count; i++)
            {
                var office = _bakeryOffices[i];
                int index = i;
                mainMenuOptions.AddOption(
                    i + 1,
                    $"{office.Name}",
                    () =>
                    {
                        HandleBakeryOfficeMenu(index);
                    }
                );
            }

            while (true)
            {
                mainMenuOptions.PrintOptions();

                string input = Validation.GetValidInput("Select the office to make an order:");

                if (int.TryParse(input, out int option))
                {
                    if (option == 0)
                        break;

                    mainMenuOptions.ExecuteOption(option);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }

                Console.WriteLine("\n=============================================");
            }
        }

        private void HandleBakeryOfficeMenu(int index)
        {
            var office = _bakeryOffices[index];
            // List<OrderItem> orders = new List<OrderItem>();

            while (true)
            {
                var bakeryOption = new OptionManagerService();
                bakeryOption.AddOption(
                    1,
                    "Add Order",
                    () =>
                    {
                        AddOrder(index);
                    }
                );

                if (_bakeryOffices[index].Orders.Any())
                {
                    bakeryOption.AddOption(
                        2,
                        "Prepare all the orders",
                        () =>
                        {
                            PrepareOrders(index);
                        }
                    );
                }

                bakeryOption.AddOption(
                    0,
                    "Go back to the main menu",
                    () =>
                    {
                        return;
                    }
                );

                Console.WriteLine("\n");
                bakeryOption.PrintOptions();
                string input = Validation.GetValidInput($"{office.Name} - Select an Option:");

                if (int.TryParse(input, out int option))
                {
                    if (option == 0)
                        break;

                    bakeryOption.ExecuteOption(option);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private void AddOrder(int index)
        {
            var office = _bakeryOffices[index];
            var menuOption = new OptionManagerService();

            for (int i = 0; i < office.Menu.Count; i++)
            {
                var itemMenu = office.Menu[i];

                menuOption.AddOption(
                    i + 1,
                    $"{office.Menu[i].Name} - {office.Menu[i].Price} $us",
                    () =>
                    {
                        Console.WriteLine($"Select the quantity of {itemMenu.Name}:");
                        string quantity = Validation.GetValidInput("Quantity:");

                        var orderItem = new OrderItem(itemMenu, int.Parse(quantity));
                        var order = new Order(new List<OrderItem>() { orderItem });
                        if (int.TryParse(quantity, out int option))
                        {
                            if (option == 0)
                            {
                                Console.WriteLine("⚠️  Invalid option. Please try again.");
                                return;
                            }
                            var totalOrders =
                                office.Orders.Sum(order => order.TotalBreads())
                                + orderItem.Quantity;

                            Console.WriteLine($"⚠️  {office.Capacity} : {totalOrders}.");

                            if (totalOrders > office.Capacity)
                            {
                                Console.WriteLine("⚠️  The bakery has reached its order capacity.");
                                return;
                            }

                            _bakeryOffices[index].AddOrder(order);
                            Console.WriteLine($" {_bakeryOffices[index].Orders.Count}");

                            Console.WriteLine($"✅ {orderItem.Bread.Name} added to the order!");
                        }
                        else
                        {
                            Console.WriteLine("⚠️  Invalid option. Please try again.");
                        }
                    }
                );
            }

            while (true)
            {
                Console.WriteLine("\n");
                menuOption.PrintOptions();
                string input = Validation.GetValidInput($"{office.Name} - Select an Option:");

                if (int.TryParse(input, out int option))
                {
                    if (option == 0)
                    {
                        break;
                    }

                    menuOption.ExecuteOption(option);
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private void PrepareOrders(int index)
        {
            var office = _bakeryOffices[index];
            var printer = new RecipePrinterService();
            Console.WriteLine($"\nPreparing {office.Orders.Count} orders at {office.Name}...");

            _breadService.PrintAllRecipes(office);

            _bakeryOffices[index].Orders.Clear();
            Console.WriteLine("✅ All orders have been prepared!");
        }
    }
}
