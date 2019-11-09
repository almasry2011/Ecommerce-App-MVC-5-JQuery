using LeaderTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace LeaderTask.Data
{
    public class DBContextSeeder : DropCreateDatabaseIfModelChanges<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {

            Category category1 = new Category()
            {
                CategoryName = "Smart Phones",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName="Samsung Galaxy S3",
                        UnitPrice=5000,
                        UnitsInStock=10,
                        Image="https://drop.ndtv.com/TECH/product_database/images/442014103050AM_635_samsung_galaxy_s3_neo.jpeg"
                    },
                         new Product()
                    {
                        ProductName="Xiaomi Mi A1",
                        UnitPrice=4000,
                        UnitsInStock=10,
                        Image="https://www.powerplanetonline.com/cdnassets/xiaomi_mi_a1_premium_protection_twilight_aurora_funda_01_l.jpg"
                    },
                         new Product()
                    {
                        ProductName="nokia 6.1 plus",
                        UnitPrice=6000,
                        UnitsInStock=20,
                        Image="https://images-na.ssl-images-amazon.com/images/I/81BezgDRxuL._SX679_.jpg"
                    },
                }
            };

            Category category2 = new Category()
            {
                CategoryName = "Smart TV's",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        ProductName="40 LED Smart TV Full HD 1080p With Freeview HD",
                        UnitPrice=10000,
                        UnitsInStock=50,
                        Image="https://images-na.ssl-images-amazon.com/images/I/61z-k3jSSkL._SX425_.jpg"
                    },
                         new Product()
                    {
                        ProductName="LG Full HD 43 inch Smart TV ",
                        UnitPrice=7000,
                        UnitsInStock=20,
                        Image="https://www.lg.com/au/images/tvs/md05804349/gallery/43LJ550T_d1_210917.jpg"
                    } 
                }
            };
            Customer customer1 = new Customer
            {
                CustomerName = "Amr Mohamed",
                Country = "Egypt",
                Email = "almasry201174@gmail.com",
                Phone = "01092259518",
                Image = "https://www.deviersprong.nl/wp-content/uploads/2017/11/img-person-placeholder.jpg"
                ,UserName="amr",
                Password="123"
            };

            Customer customer2 = new Customer
            {
                CustomerName = "Hossam EL-Moghazy",
                Country = "Egypt",
                Email = "Hossam000@gmail.com",
                Phone = "01002559518",
                Image = "https://www.deviersprong.nl/wp-content/uploads/2017/11/img-person-placeholder.jpg",
                UserName = "amr",
                Password = "123"
            };
            Customer customer3 = new Customer
            {
                CustomerName = "Khaled El -Sayed",
                Country = "Egypt",
                Email = "Khaled000@gmail.com",
                Phone = "0100252518",
                Image = "https://www.deviersprong.nl/wp-content/uploads/2017/11/img-person-placeholder.jpg",
                UserName = "amr",
                Password = "123"
            };


            context.Categories.AddOrUpdate(category1);
            context.Categories.AddOrUpdate(category2);
            context.Customers.AddOrUpdate(customer1);
            context.Customers.AddOrUpdate(customer2);
            context.Customers.AddOrUpdate(customer3);

            context.SaveChanges();

            base.Seed(context);


        }
    }
}