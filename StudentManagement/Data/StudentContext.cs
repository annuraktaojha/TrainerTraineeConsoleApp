using Microsoft.EntityFrameworkCore;
using StudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=INBMWN177550\\SQLEXPRESS;Initial Catalog=StudentDBEFCORE;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        public DbSet <Student> Students { get; set; }
    }
}
