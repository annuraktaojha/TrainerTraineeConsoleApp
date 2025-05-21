namespace LinqtoObjectsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. List all products whose price in between 50K to 80K

            var products = (from product in ProductsDB.GetProducts()
                           where product.Price >= 50000 && product.Price <= 80000
                           select product).ToList();

            foreach (var p in products)
            { 
                Console.WriteLine(p.Name + " " + p.Price + " " );
            }
           // Console.WriteLine($"products whose price in between 50K to 80K are : {products} ");

            //2. Extract all products belongs to Laptops catagory

             var laptops = (from product in ProductsDB.GetProducts()
                           where product.Catagory.Name == "Laptops"
                           select product).ToList();

            foreach (var p in laptops)
            {
                Console.WriteLine(p.Name + " " + p.Price + " " + p.Catagory.Name);
            }
            // Console.WriteLine($"products belongs to Laptops catagory are : {laptops} ");-- wrongo/p

            //3. Extract/Show Product Name and Catagory Name only

            var productDetails = (from product in ProductsDB.GetProducts()
                                 select new { ProductName = product.Name, CatagoryName = product.Catagory.Name })
                                 .ToList();

            foreach (var p in productDetails)
            {
                Console.WriteLine(p.ProductName + " " + p.CatagoryName);
            }
            // Console.WriteLine(productDetails);
           // Console.WriteLine($"Product Name and Catagory Name only are : {productDetails}");

            //4. Show the costliest product name 
             var costliestProduct = (from product in ProductsDB.GetProducts()
                                     orderby product.Price descending
                                     select product.Name).FirstOrDefault();
            Console.WriteLine($"costliest product name is : {costliestProduct}");

            //5. Show the cheepest product name and its price
            var cheapestProduct = (from product in ProductsDB.GetProducts()
                                   orderby product.Price
                                   select new { ProductName = product.Name, ProductPrice = product.Price }).FirstOrDefault();

            Console.WriteLine($"cheapest product name : {cheapestProduct.ProductName}  and its price is : {cheapestProduct.ProductPrice}");


            //Console.WriteLine($"cheapest product name and its price is : {cheapestProduct}");


            //6. Show the 2nd and 3rd product details

             var productDetails2nd3rd = ((from product in ProductsDB.GetProducts()
                                         select product).Skip(1).Take(2)).ToList();

           // Console.WriteLine($"2nd and 3rd product details are : {productDetails2nd3rd}");

            foreach (var p in productDetails2nd3rd)
            {
                Console.WriteLine(p.Name + " " + p.Price + " " + p.Catagory.Name);
            }
            //7. List all products in assending order of their price

            var productsInAssendingOrder = (from product in ProductsDB.GetProducts()
                                           orderby product.Price
                                           select product).ToList();

            foreach (var item in productsInAssendingOrder)
            {
                Console.WriteLine(item.Name + " " + item.Price + " " + item.Catagory.Name);
            }
            //Console.WriteLine($"products in assending order of their price are : {productsInAssendingOrder}"); wrong o/p
            //8. Count the no. of products belong to Tablets
            var tabletsCount = (from product in ProductsDB.GetProducts()
                                where product.Catagory.Name == "Tablets"
                                select product).Count();
            Console.WriteLine($"no. of products belong to Tablets are : {tabletsCount}");

            //9. Show which catagory has costly product

            var costlyCatagory = (from product in ProductsDB.GetProducts()
                                  group product by product.Catagory.Name into g
                                  select new { CatagoryName = g.Key, CostlyProduct = g.Max(p => p.Price) }).FirstOrDefault();

            Console.WriteLine($"catagory has costly product is : {costlyCatagory.CatagoryName}");


            //10. Show which catagory has less products

            var lessProductsCatagory = (from product in ProductsDB.GetProducts()
                                        group product by product.Catagory.Name into g
                                        select new { CatagoryName = g.Key, ProductCount = g.Count() })
                                                    .OrderBy(p => p.ProductCount).FirstOrDefault();

            Console.WriteLine($"catagory has less products is : {lessProductsCatagory.CatagoryName}");
            //11. Extract the Product Details based on the catagory and show as below

            //            Laptops
            //                Dell XPS 13

            //    HP 430
            //Mobiles
            //    IPhone 6

            //    Galaxy S6
            //Tablets
            //    IPad Pro

            var ProductDetailsBasedOnCatagory = from product in ProductsDB.GetProducts()
                                                    group product by product.Catagory.Name into g
                                                    select new { CatagoryName = g.Key, Products = g.Select(p => p.Name) };

            foreach (var item in ProductDetailsBasedOnCatagory)
            {
                Console.WriteLine(item.CatagoryName);
                foreach (var product in item.Products)
                {
                    Console.WriteLine(product);
                }
            }
              //  Console.WriteLine($"Product Details based on the catagory are : {ProductDetailsBasedOnCatagory}");

            //12. Extract the Product count based on the catagory and show as below


            //        Laptops : 2
            //Mobiles: 2
            //Tablets: 1

            var ProductCountBasedOnCatagory = from product in ProductsDB.GetProducts()
                                              group product by product.Catagory.Name into g
                                              select new { CatagoryName = g.Key, ProductCount = g.Count() };
            foreach (var item in ProductCountBasedOnCatagory)
            {
                Console.WriteLine($"{item.CatagoryName} : {item.ProductCount}");
            }
           // Console.WriteLine($"Product count based on the catagory are : {ProductCountBasedOnCatagory}");


        }
    }

    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}
