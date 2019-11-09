using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeaderTask.Models
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Quatity { get; set; }

        public int OrderId { get; set; }
        public virtual Order order { get; set; }

        public int ProductID { get; set; }
        public virtual Product product { get; set; }


    }
}