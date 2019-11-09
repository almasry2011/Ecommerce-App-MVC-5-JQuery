using LeaderTask.Data;
using LeaderTask.Infrastructure;
using LeaderTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeaderTask.Repositorys
{
    public class Orders_Repo  
    {
        TaskContext db;
        Cart_Repository _crtRepo;
        public Orders_Repo()
        {
              db = new TaskContext();
            _crtRepo = new Cart_Repository();
        }
        public async Task<int> Add(Order order,string username)
        {
            var customer =await db.Customers.SingleOrDefaultAsync(c => c.UserName == username);
            var CustomerCart = await _crtRepo.GetUserCart(username);
            order.CustomerID = customer.CustomerID;
            db.Orders.Add(order);
            IList<ProductOrder> productOrderList = new List<ProductOrder>();
            foreach (var item in CustomerCart)
            {
                var ProductOrder = new ProductOrder
                {
                    OrderId=order.OrderId,
                    ProductID=item.ProductID,
                    Quatity=item.amount
                };
                productOrderList.Add(ProductOrder);
            }
             db.ProductOrders.AddRange(productOrderList);
             await  _crtRepo.RemoveAllCart(username);
             return await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<  Order>>  GetAllOrders()
        {
            var res =await db.Orders.ToListAsync();
            return res;
        }
        public async Task<IEnumerable<ProductOrder>> GetOrder(int id)
        {
                  var UserOrders =await db.ProductOrders.Where(o => o.OrderId == id).Include(p=>p.product)   .ToListAsync();
                 return UserOrders;
        }

    }
}
