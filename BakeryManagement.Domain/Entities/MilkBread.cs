namespace BakeryManagement.Domain.Entities
{
    public class MilkBread : Bread
    {
        public MilkBread()
            : base(
                "Milk Bread",
                2.5,
                new Dictionary<string, double>
                {
                    { "Flour", 1000 },
                    { "Water", 280 },
                    { "Salt", 20 },
                    { "Yeast", 20 },
                    { "Sugar", 80 },
                    { "Milk", 60 },
                    { "Butter", 100 },
                },
                TimeSpan.FromMinutes(30),
                TimeSpan.FromHours(1),
                TimeSpan.FromHours(4),
                180
            ) { }
    }
}
