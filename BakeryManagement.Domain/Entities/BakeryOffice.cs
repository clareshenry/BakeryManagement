namespace BakeryManagement.Domain.Entities
{
    public class BakeryOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Bread> Menu { get; }

        public List<Order> Orders { get; } = new List<Order>();

        public BakeryOffice(string name, int capacity, List<Bread> menu)
        {
            Name = name;
            Capacity = capacity;
            Menu = menu;
        }

        public int RemainingCapacity()
        {
            return Capacity - Orders.Sum(order => order.TotalBreads());
        }

        public void AddOrder(Order order)
        {
            Console.WriteLine($" remaining{RemainingCapacity()} order{order.TotalBreads()}");
            if (RemainingCapacity() >= order.TotalBreads())
            {
                Orders.Add(order);
                Console.WriteLine($"Order added to {Name}.");
                var total = Orders.Sum(order => order.TotalBreads());
                Console.WriteLine($"Total breads: {total}");
            }
            else
            {
                Console.WriteLine(
                    $"Cannot add order. Maximum capacity exceeded. You can add up to {RemainingCapacity()} more breads."
                );
            }
        }
    }
}
