// See https://aka.ms/new-console-template for more information
using BakeryManagement.Application.Services;
using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using BakeryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
var config = configuration.Build();

IConfigurationSection connectionString = config.GetSection("ConnectionString");

var serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString["DataConnection"])
    )
    // .AddScoped<IBreadRepository, BreadRepository>()
    // .AddScoped<BreadService>()
    .BuildServiceProvider();

var breadService = serviceProvider.GetRequiredService<BreadService>();

while (true)
{
    Console.WriteLine("\nBakery Management System");
    Console.WriteLine("1. Show all breads");
    Console.WriteLine("2. Add a new bread");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            var breads = await breadService.GetAllBreadsAsync();
            foreach (var bread in breads)
            {
                Console.WriteLine($"- {bread.Name}");
            }
            break;
        case "2":
            Console.Write("Enter bread name: ");
            string name = Console.ReadLine() ?? string.Empty;

            var newBread = new Baguette();
            await breadService.AddBreadAsync(newBread);
            Console.WriteLine("Bread added successfully!");
            break;
        case "3":
            return;
        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}
