namespace BakeryManagement.Domain.Entities
{
    public class BakeryOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        // public List<Order> Orders { get; } = new List<Order>();
        // public List<Bread> Menu { get; }

        // public BakeryOffice(string name, int capacity)
        // {
        //     Name = name;
        //     Capacity = capacity;
        //     // Menu = menu;
        // }

        // public int RemainingCapacity()
        // {
        //     return Capacity - Orders.Sum(order => order.TotalBreads());
        // }
        //
        // public void AddOrder(Order order)
        // {
        //     if (RemainingCapacity() >= order.TotalBreads())
        //     {
        //         Orders.Add(order);
        //         Console.WriteLine($"Order added to {Name}.");
        //     }
        //     else
        //     {
        //         Console.WriteLine(
        //             $"Cannot add order. Maximum capacity exceeded. You can add up to {RemainingCapacity()} more breads."
        //         );
        //     }
        // }
        //
        // public void PrepareOrders()
        // {
        //     if (Orders.Count == 0)
        //     {
        //         Console.WriteLine("No orders to prepare.");
        //         return;
        //     }
        //
        //     Console.WriteLine($"Preparing all orders for {Name}...");
        //     foreach (var order in Orders)
        //     {
        //         order.Prepare();
        //     }
        //
        //     Orders.Clear();
        //     Console.WriteLine("All orders completed!");
        // }
    }
}
