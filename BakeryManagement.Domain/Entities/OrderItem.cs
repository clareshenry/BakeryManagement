namespace BakeryManagement.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; }
        public Bread Bread { get; }
        public int Quantity { get; }
        public double Total => Bread.Price * Quantity;

        public OrderItem(Bread bread, int quantity)
        {
            Id = Guid.NewGuid();
            Bread = bread;
            Quantity = quantity;
        }
    }
}
