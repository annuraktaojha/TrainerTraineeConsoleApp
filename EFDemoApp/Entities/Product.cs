using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Brand { get; set; }
        //public string Description { get; set; }
        //public string Category { get; set; }
        //public List<Product> Products { get; set; }

        public virtual Category Category { get; set; }
    }

   public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; }
    }
}
