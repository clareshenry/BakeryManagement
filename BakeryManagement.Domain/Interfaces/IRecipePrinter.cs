namespace BakeryManagement.Domain.Interfaces
{
    public interface IRecipePrinter
    {
        void PrintRecipe(string breadType, int quantity, Dictionary<string, double> ingredients);
    }
}
