namespace BakeryManagement.Domain.Entities
{
    public class HamburguerBun : Bread
    {
        public HamburguerBun()
            : base(
                "Hamburguer Bun",
                1.5,
                new Dictionary<string, double>
                {
                    { "Flour", 100 },
                    { "Water", 25 },
                    { "Salt", 2 },
                    { "Yeast", 4 },
                    { "Sugar", 6 },
                    { "Egg", 10 },
                    { "Milk", 5 },
                    { "Butter", 6 },
                    { "Sweet Potato", 25 },
                    { "Sesame seed", 10 },
                    { "Gilding", 5 },
                },
                TimeSpan.FromMinutes(30),
                TimeSpan.FromHours(1),
                TimeSpan.FromHours(4),
                180
            ) { }
    }
}
