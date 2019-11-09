using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaderTask.Models
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }
        public int OrderId { get; set; }
        public string ShipName { get; set; }
        public string ShipEmail { get; set; }
        public string Phone { get; set; }
        public string ShipAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductOrder> ProductOrder { get; set; }
    }
}