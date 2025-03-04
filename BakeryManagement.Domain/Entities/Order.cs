namespace BakeryManagement.Domain.Entities
{
    public class Order
    {
        public int Id { get; }
        public List<OrderItem> Breads { get; }
        public double TotalCost => Breads.Sum(item => item.Total);

        public Order(int id, List<OrderItem> breads)
        {
            Id = id;
            Breads = breads;
        }

        public int TotalBreads() => Breads.Sum(item => item.Quantity);

        public void Prepare()
        {
            Console.WriteLine($"Preparing order {Id}...");
            foreach (var item in Breads)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    item.Bread.Prepare();
                }
            }
        }
    }
}
