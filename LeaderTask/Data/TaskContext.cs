using LeaderTask.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeaderTask.Data
{
    public class TaskContext:DbContext
    {
        public TaskContext() : base("DefaultConnection")
        {


            //Database.SetInitializer(new DBContextSeeder());
            //var db = new TaskContext();
            //db.Database.Initialize(true);

            this.Configuration.LazyLoadingEnabled = false;



        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

    }
}