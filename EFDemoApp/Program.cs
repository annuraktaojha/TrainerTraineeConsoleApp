using EFDemoApp.DataLayer;
using EFDemoApp.Entities;

namespace EFDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //save Productdata
            //Save();

            // get all Products 
            //DisplayAllProducts();

            // get product to edit

            //Update();

            // get the object to delete
            //DeleteProductById(3);

            // Add
            // 
            ProductDbContext db = new ProductDbContext();
            Category category = new Category
            {
                CategoryName = "Mobiles"
                    ,
                CategoryDescription = "premium mobiles"
            };
            Product product = new Product
            {
                Name = "Galaxy S22",
                Brand = "Samsung",
                Price = 99999,
                Category = category
            };
            db.Products.Add(product);
            db.SaveChanges();
            // add a new product with existing category
            // get the 
            //var cat = db.Categories.Find(1);


        }

        private static void DeleteProductById(int id)
        {
            ProductDbContext db = new ProductDbContext();
            var prouctToDelete = db.Products.Find(id);
            db.Products.Remove(prouctToDelete);
            db.SaveChanges();
        }

        private static void Update()
        {
            ProductDbContext db = new ProductDbContext();
            var ProducttoEdit = (from p in db.Products
                                 where p.ProductId == 1
                                 select p).FirstOrDefault();
            ProducttoEdit.Price = 99999;
            db.SaveChanges();
        }

        private static void DisplayAllProducts()
        {
            ProductDbContext productDb = new ProductDbContext();

            var products = from prod in productDb.Products
                           select prod;

            foreach (var prod in products)
            {
                Console.WriteLine(prod.Name);
            }
        }

        public static void Save()
        {
            Product product = new Product();

            product.Name = " Samsung S24+";
            product.Price = 500;

            ProductDbContext productDbContext = new ProductDbContext();
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();
        }
    }
}
