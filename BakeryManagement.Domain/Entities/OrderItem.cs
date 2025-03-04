namespace BakeryManagement.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; }
        public Bread Bread { get; }
        public int Quantity { get; }
        public double Total => Bread.Price * Quantity;

        public OrderItem(int id, Bread bread, int quantity)
        {
            Id = id;
            Bread = bread;
            Quantity = quantity;
        }
    }
}
