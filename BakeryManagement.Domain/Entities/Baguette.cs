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
    }
}
