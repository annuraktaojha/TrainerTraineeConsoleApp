namespace CompanyDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // sample data

            var items=new List<Item>
            {
                new Item { Id = 1, Description = "Item 1", Rate = 100 },
                new Item { Id = 2, Description = "Item 2", Rate = 200 },
                new Item { Id = 3, Description = "Item 3", Rate = 300 },
                new Item { Id = 4, Description = "Item 4", Rate = 400 },
                new Item { Id = 5, Description = "Item 5", Rate = 500 }
            };

            var customers = new List<Customer>
            {
                new Customer { Id=1, Name="XYZ" },
                new RegCustomer {  Id=2,Name="ABC", SplDiscount = 10 }
            };

            var orders = new List<Order>
            {
                new Order { Customer = customers[0], OrderItems = new List<OrderItem> { new OrderItem { Item = items[0], Quantity = 1 } } },
                new Order { Customer = customers[1], OrderItems = new List<OrderItem> { new OrderItem { Item = items[1], Quantity = 2 } } }
            };

            // calculate total worth of orders placed

            var company = new Company();
            double totalWorth = company.GetTotalWorthOfOrdersPlaced(orders);

            Console.WriteLine($"Total worth of orders placed: {totalWorth}");
            Console.ReadKey();
        }
    }

    //interface IOrderService
    //{
    //    double GetTotalWorthOfOrdersPlaced(List<Order> orders);
    //}

    class Company //: IOrderService
    {
        public double GetTotalWorthOfOrdersPlaced(List<Order> orders)
        {
            double totalWorth = 0;

            foreach (var order in orders)
            {
                double orderTotal = 0;
                foreach (var orderItem in order.OrderItems)
                {
                    orderTotal += (double)(orderItem.Item.Rate * orderItem.Quantity);
                }

                if (order.Customer is RegCustomer)
                {
                    orderTotal -= orderTotal * ((RegCustomer)order.Customer).getSplDiscount();
                }
                totalWorth += orderTotal;
            }
            return totalWorth;
        }
    }
 

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        //  public Company Company { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }

    class RegCustomer : Customer
    {
        public double SplDiscount { get; set; }

        public double getSplDiscount()
        {
            return SplDiscount/100;
        }
    }

    public class Item {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }
    }
    
    class Order
    {
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        //public decimal GetTotalAmount() { return 0; }
        //public int GetItemsCount() { return 0; }
        //public DateTime GetOrderDate() { return DateTime.Now; }
    }

    public class OrderItem
    {
       // public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        //public decimal GetAmount() { return 0; }
    }
}
