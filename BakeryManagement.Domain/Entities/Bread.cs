namespace BakeryManagement.Domain.Entities
{
    public abstract class Bread
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public Dictionary<string, double> Ingredients { get; protected set; }
        public TimeSpan CookingTime { get; protected set; }
        public TimeSpan RestingTime { get; protected set; }
        public TimeSpan FermentTime { get; protected set; }
        public double Temperature { get; protected set; }

        public Bread(
            string name,
            double price,
            Dictionary<string, double> ingredients,
            TimeSpan cookingTime,
            TimeSpan restingTime,
            TimeSpan fermentTime,
            double temperature
        )
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            CookingTime = cookingTime;
            RestingTime = restingTime;
            FermentTime = fermentTime;
            Temperature = temperature;
        }
    }
}
