using BakeryManagement.Application.Services;
using BakeryManagement.Application.Utils;

var bakeryService = new BakeryService();
bakeryService.PrintOptionMenu();

Console.WriteLine("Bye!");

Console.ReadLine();
