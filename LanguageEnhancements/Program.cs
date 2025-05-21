using System.Security.Cryptography.X509Certificates;

namespace LanguageEnhancements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = 11;

            var str = "Hello";

            Dictionary<int, List<string>> keyValuePairs = new Dictionary<int, List<string>>();

            var keyValuePairs2 = new Dictionary<int, List<string>>();

            //1st Feature: var keyword

            // 2nd Feature: object initialization syntax


            Product product = new Product();
            product.Id = 1;

            product.Name = "Laptop";
            product.Price = 1000;
            product.Brand = "Dell";
           // Product product1 = new Product(5, "Laptop", 1000, "HP");

            Product product2 = new Product
            {
                Id = 2,
                Name = "Mobile",
                Price = 500,
                Brand = "Samsung"
            };

            Product product3 = new Product
            {
                Id = 3,
                Name = "Tablet",
                Price = 300,
                Brand = "Apple"
            };

            //3rd Feature: Anonymous types

            var emp= new { Id = 1, Name = "John", Salary = 1000 };

            Console.WriteLine(emp.Id);

            // 4th Feature: Extension methods

            string str1 = "Some confidential data";

            string encryptedData = StringExtensions.Encrypt(str1);

            


        }
    }

    public static class StringExtensions
    {
        public static string Encrypt(this Object data)
        {
            return "Encrypted Data";
        }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Brand { get; set; }

        //public Product()
        //{
            
        //}

        //public Product(int id, string name, double price, string brand)
        //{
        //    Id = id;
        //    Name = name;
        //    Price = price;
        //    Brand = brand;

        //}
    }
}