namespace BakeryManagement.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; }
        public List<OrderItem> Breads { get; }
        public double TotalCost => Breads.Sum(item => item.Total);

        public Order(List<OrderItem> breads)
        {
            Id = Guid.NewGuid();
            Breads = breads;
        }

        public int TotalBreads() => Breads.Sum(item => item.Quantity);
    }
}
