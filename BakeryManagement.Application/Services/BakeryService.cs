// using BakeryManagement.Application.Utils;

using BakeryManagement.Application.Utils;
using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Application.Services
{
    public class BakeryService
    {
        private readonly BakeryOfficeService _bakeryOfficeService;

        private readonly MenuService _menuService;

        public BakeryService(BakeryOfficeService bakeryOfficeService, MenuService menuService)
        {
            _bakeryOfficeService = bakeryOfficeService;
            _menuService = menuService;
        }

        public async Task PrintOptionMenu()
        {
            var mainMenuOptions = new OptionManagerService();

            var offices = await _bakeryOfficeService.GetAllAsync();
            if (!offices.Any())
            {
                Console.WriteLine("There are no bakery offices");
                return;
            }

            foreach (var office in offices)
            {
                mainMenuOptions.AddOption(
                    office.Id,
                    async () => await HandleBakeryOfficeMenu(office.Id),
                    office.Name
                );
            }

            mainMenuOptions.AddOption(
                0,
                () =>
                {
                    return Task.CompletedTask;
                },
                "Exit"
            );

            Console.WriteLine("Bakery Fresh Bread");
            Console.WriteLine("--------------------------------------------");

            await mainMenuOptions.ShowOptionsAsync();
        }

        async Task HandleBakeryOfficeMenu(int bakeryOfficeId)
        {
            // Console.WriteLine($"Welcome to {bakeryOfficeId}");
            var office = await _bakeryOfficeService.GetByIdAsync(bakeryOfficeId);
            if (office == null)
            {
                Console.WriteLine("There are no bakery offices");
                return;
            }

            var bakeryOption = new OptionManagerService();

            bakeryOption.AddOption(1, async () => await AddOrder(bakeryOfficeId), "Add Order");

            if (office.Orders.Any())
            {
                bakeryOption.AddOption(
                    2,
                    async () => await PrepareOrders(bakeryOfficeId),
                    "Prepare all the orders"
                );
            }

            bakeryOption.AddOption(
                0,
                () =>
                {
                    return Task.CompletedTask;
                },
                "Go back to the main menu"
            );

            await bakeryOption.ShowOptionsAsync();
        }

        private async Task AddOrder(int bakeryOfficeId)
        {
            var office = await _bakeryOfficeService.GetByIdAsync(bakeryOfficeId);
            if (office == null)
            {
                Console.WriteLine("There are no bakery offices");
                return;
            }

            var menuOption = new OptionManagerService();

            var menu = await _menuService.GetMenuByOfficeId(bakeryOfficeId);

            foreach (var itemMenu in menu)
            {
                menuOption.AddOption(
                    itemMenu.Id,
                    async () => await AddOrderItem(bakeryOfficeId, itemMenu.Bread),
                    $"{itemMenu.Bread.Name} - {itemMenu.Bread.Price} $us"
                );
            }
            menuOption.AddOption(
                0,
                () =>
                {
                    return Task.CompletedTask;
                },
                "Go back to the main menu"
            );

            await menuOption.ShowOptionsAsync();
        }

        private async Task AddOrderItem(int bakeryOfficeId, Bread bread)
        {
            Console.WriteLine($"Select the quantity of {bread.Name}:");

            var quantity = Validation.GetValidInput("Quantity:");
            if (int.TryParse(quantity, out int quantityOption))
            {
                if (quantityOption == 0)
                {
                    Console.WriteLine("⚠️  Invalid option. Please try again.\n");
                    return;
                }
                var office = await _bakeryOfficeService.GetByIdAsync(bakeryOfficeId);

                if (office == null)
                {
                    Console.WriteLine("There are no bakery offices");
                    return;
                }

                var total =
                    await _bakeryOfficeService.GetTotalOrderItemsQuantityByBakeryOfficeIdAsync(
                        bakeryOfficeId
                    );

                Console.WriteLine($"⚠️  Office orders : {total}");

                var totalOrders = total + quantityOption;

                Console.WriteLine($"⚠️  Capacity {totalOrders}/{office.Capacity}.");

                if (totalOrders > office.Capacity)
                {
                    Console.WriteLine("⚠️  The bakery has reached its order capacity.");
                    return;
                }

                await _bakeryOfficeService.AddOrder(bakeryOfficeId, bread.Id, quantityOption);

                Console.WriteLine($"✅ {bread.Name} added to the order! \n");
            }
            else
            {
                Console.WriteLine("⚠️  Invalid option. Please try again.");
            }
        }

        private async Task PrepareOrders(int bakeryOfficeId)
        {
            // TODO: print all the orders
            await _bakeryOfficeService.PrepareAllOrders(bakeryOfficeId);
            // var office = _bakeryOffices[index];
            // var printer = new RecipePrinterService();
            // Console.WriteLine($"\nPreparing {office.Orders.Count} orders at {office.Name}...");
            //
            // _breadService.PrintAllRecipes(office);
            //
            // _bakeryOffices[index].Orders.Clear();
            // Console.WriteLine("✅ All orders have been prepared!");
        }
    }
}
