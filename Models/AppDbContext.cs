using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;



namespace EmployeeManager.Mvc.Models
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; } 
        
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Shippers> Shippers { get; set; }

        public DbSet<Suppliers> Suppliers { get; set; }

    }
}
