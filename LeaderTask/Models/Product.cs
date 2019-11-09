using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaderTask.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }

    }
}