using EFDemoApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemoApp.DataLayer
{
    public class ProductDbContext: DbContext
    {

        // map to database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=INBMWN177550\\SQLEXPRESS;Initial " +
                "Catalog=DBEFCORE;Integrated Security=True;Encrypt=False;Trust Server Certificate=True; MultipleActiveResultSets=True")
                .LogTo(Console.WriteLine,LogLevel.Information)
                .UseLazyLoadingProxies();

        }

        //2. map to tables

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
