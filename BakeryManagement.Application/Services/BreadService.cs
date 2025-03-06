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
                .Orders.SelectMany(order => order.Breads)
                .GroupBy(orderItem => orderItem.Bread.Name)
                .Select(group => new
                {
                    BreadType = group.Key,
                    Quantity = group.Sum(item => item.Quantity),
                    SampleBread = group.First().Bread,
                })
                .ToList();

            foreach (var breadOrder in breadOrders)
            {
                _recipePrinter.PrintRecipe(
                    breadOrder.BreadType,
                    breadOrder.Quantity,
                    breadOrder.SampleBread.Ingredients
                );
            }
        }
    }
}
