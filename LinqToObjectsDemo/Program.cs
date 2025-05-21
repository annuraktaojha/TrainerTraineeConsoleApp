using System.ComponentModel;

namespace LinqToObjectsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Get all products name and display
            var result1 = from p in Product.GetProducts()
                          select new { Name = p.Name, Rate = p.Price, CName = p.category.Name };

            //foreach (var p in result1) { Console.WriteLine(p.Name + " " + p.Rate + " " + p.CName); }

            //2. Get expensive product name
            var expensiveProduct = (from p in Product.GetProducts()
                                    orderby p.Price descending
                                    select p.Name).FirstOrDefault();
            //Console.WriteLine(expensiveProduct);

            //3. get the total of all product price

            var totalSum = (from p in Product.GetProducts()
                            select p.Price).Sum();

            Console.WriteLine(totalSum);
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }

        public string Country { get; set; }

        public bool InStock { get; set; }

        public Category category { get; set; }

        public static List<Product> GetProducts()
        {
            List<Category> categories
                = new List<Category>()
                {
                    new Category() { Id = 1,    Name = "Electronics" },
                    new Category() { Id = 2,    Name = "Grocery" },
                    new Category() { Id = 3,    Name = "Apparel" }
                };
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Laptop", Price = 1000, Brand = "Dell", Country = "USA", InStock = true, category = categories[0] },
                new Product() { Id = 2, Name = "Mobile", Price = 500, Brand = "Samsung", Country = "Korea", InStock = false, category = categories[0] },
                new Product() { Id = 3, Name = "Shirt", Price = 30, Brand = "Peter England", Country = "India", InStock = true, category = categories[2] },
                new Product() { Id = 4, Name = "Pant", Price = 40, Brand = "Levis", Country = "India", InStock = false, category = categories[2] },
                new Product() { Id = 5, Name = "Rice", Price = 20, Brand = "India Gate", Country = "India", InStock = true, category = categories[1] },
                new Product() { Id = 6, Name = "Wheat", Price = 30, Brand = "Aashirvaad", Country = "India", InStock = false, category = categories[1] }
            };
            return products;
        }
    }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
}
