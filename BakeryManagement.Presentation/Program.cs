using BakeryManagement.Application.Services;
using BakeryManagement.Domain.Entities;
using BakeryManagement.Infrastructure.Database;
using BakeryManagement.Infrastructure.Repositories;

var context = new AppDbContext();
try
{
    var bakeryService = new BakeryService(
        new BakeryOfficeService(
            new BakeryOfficeRepository(context),
            new OrderRepository(context),
            new OrderItemRepository(context)
        ),
        new MenuService(new MenuRepository(new AppDbContext()))
    );

    await bakeryService.PrintOptionMenu();
}
catch (System.Exception ex)
{
    Console.WriteLine("Error", ex);
}

Console.WriteLine("Bye!");
Console.ReadLine();
