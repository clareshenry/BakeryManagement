using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class BreadService
    {
        private readonly IRecipePrinter _recipePrinter;

        public BreadService(IRecipePrinter recipePrinter)
        {
            _recipePrinter = recipePrinter;
        }

        public void PrintAllRecipes(BakeryOffice bakeryOffice)
        {
            var breadOrders = bakeryOffice
                .Orders.SelectMany(order => order.Breads) // Flatten OrderItems
                .GroupBy(orderItem => orderItem.Bread.Name) // Group by bread name
                .Select(group => new
                {
                    BreadType = group.Key,
                    Quantity = group.Sum(item => item.Quantity), // Sum all quantities
                    SampleBread = group.First().Bread, // Get a sample bread object for ingredients
                })
                .ToList();

            foreach (var breadOrder in breadOrders)
            {
                var quantity = breadOrders.Count();

                _recipePrinter.PrintRecipe(
                    breadOrder.BreadType,
                    quantity,
                    breadOrder.SampleBread.Ingredients
                );
            }
        }
    }
}
