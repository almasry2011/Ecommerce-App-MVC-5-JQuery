using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaderTask.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int amount { get; set; }
        public DateTime CreatedDate { get; set; }
        //public string Username { get; set; }

        public int ProductID { get; set; }
        public Product product { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer customer { get; set; }

    }
}