namespace BakeryManagement.Domain.Entities
{
    public class Baguette : Bread
    {
        public Baguette()
            : base(
                "Baguette",
                2.0,
                new Dictionary<string, double>
                {
                    { "Flour", 280 },
                    { "Water", 210 },
                    { "Salt", 10 },
                    { "Yeast", 5 },
                },
                TimeSpan.FromMinutes(15),
                TimeSpan.FromMinutes(30),
                TimeSpan.FromDays(1),
                270
            ) { }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}...");
            Console.WriteLine("1. Mixing ingredients...");
            Console.WriteLine("2. Letting the dough rest for 30 minutes...");
            Console.WriteLine("3. Folding the dough...");
            Console.WriteLine("4. Letting the dough ferment for 1 day...");
            Console.WriteLine("5. Shaping the dough...");
            Console.WriteLine("6. Cooking at 270°C for 15 minutes...");
        }
    }
}
