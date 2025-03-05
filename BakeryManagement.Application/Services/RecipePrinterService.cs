using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class RecipePrinterService : IRecipePrinter
    {
        public void PrintRecipe(
            string breadType,
            int quantity,
            Dictionary<string, double> ingredients
        )
        {
            Console.WriteLine($"{breadType}\nIngredients (quantity for {quantity} bread(s))");

            string formattedIngredients = string.Join(
                ", ",
                ingredients.Select(kv => $"{kv.Value * quantity} g of {kv.Key}")
            );
            Console.WriteLine($"1. Mixing the {formattedIngredients}.");

            PrintPreparationSteps(breadType, quantity);
            Console.WriteLine();
        }

        private void PrintPreparationSteps(string breadType, int quantity)
        {
            switch (breadType)
            {
                case "Baguette":
                    PrintBaguettePreparation(quantity);
                    break;

                case "White Bread":
                    PrintWhiteBreadPreparation(quantity);
                    break;

                case "Milk Bread":
                    PrintMilkBreadPreparation(quantity);
                    break;

                case "HamburgerBun":
                    PrintHamburgerBunPreparation(quantity);
                    break;

                default:
                    Console.WriteLine("Unknown bread type.");
                    break;
            }
        }

        private void PrintBaguettePreparation(int quantity)
        {
            Console.WriteLine("2. Let the dough rest 0.5 hr.");
            Console.WriteLine("3. Fold the dough");
            Console.WriteLine("4. Let the dough rest 0.5 hr.");
            Console.WriteLine("5. Fold the dough");
            Console.WriteLine("6. Let the dough ferment 1 day.");
            if (quantity > 1)
                Console.WriteLine(
                    "7. Cut the dough (just do this step if you are making more than one bread)"
                );
            Console.WriteLine("8. Shape the dough");
            Console.WriteLine("9. Let the dough rest 0.5 hr");
            Console.WriteLine("10. Cook for 15 min at 270 degrees");
        }

        private void PrintWhiteBreadPreparation(int quantity)
        {
            if (quantity > 1)
                Console.WriteLine(
                    "2. Cut the dough (just do this step if you are making more than one bread)"
                );
            Console.WriteLine("3. Let the dough ferment 4 hrs.");
            Console.WriteLine("4. Shape the dough");
            Console.WriteLine("5. Let the dough rest 1 hr");
            Console.WriteLine("6. Cook for 30 min at 180 degrees");
        }

        private void PrintMilkBreadPreparation(int quantity)
        {
            if (quantity > 1)
                Console.WriteLine(
                    "2. Cut the dough (just do this step if you are making more than one bread)"
                );
            Console.WriteLine("3. Let the dough ferment 10 minutes.");
            Console.WriteLine("4. Shape the dough");
            Console.WriteLine("5. Let the dough ferment 4 hr");
            Console.WriteLine("6. Cook for 15 min at 180 degrees");
        }

        private void PrintHamburgerBunPreparation(int quantity)
        {
            if (quantity > 1)
                Console.WriteLine(
                    "2. Cut the dough (just do this step if you are making more than one bread)"
                );
            Console.WriteLine("3. Let the dough rest 0.5 hr");
            Console.WriteLine("4. Shape the dough");
            Console.WriteLine("5. Let the dough ferment 4 hrs");
            Console.WriteLine("6. Place on top of the dough the sesame seed and the gilding");
            Console.WriteLine("7. Cook for 15 min at 180 degrees");
        }
    }
}
