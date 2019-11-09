using LeaderTask.Data;
using LeaderTask.Infrastructure;
using LeaderTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderTask.Repositorys
{
    public   class Cart_Repository 
    {
        TaskContext db;
        public Cart_Repository()
        {
            db = new TaskContext();
        }
        public async Task<int> Add_RemoveToCart(Product product, int amount, string username)
        {
            var cartItem = await db.ShoppingCart.SingleOrDefaultAsync(s => s.customer.UserName == username
                                                                                         && s.product.ProductID == product.ProductID);
            var user = await db.Customers.SingleOrDefaultAsync(u => u.UserName == username);
            if (cartItem != null)
            {
                if (amount > 0)
                { cartItem.amount = amount; }
                if (amount <= 0)
                { db.ShoppingCart.Remove(cartItem); }
                return 1;
            } 
            else
            {
                var ShoppingCartRow = new ShoppingCart
                {
                    amount = amount,
                    CreatedDate=DateTime.Now,
                    ProductID=product.ProductID,
                    CustomerID=user.CustomerID
                };
                db.ShoppingCart.Add(ShoppingCartRow);
                if (await db.SaveChangesAsync() > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
        public async Task<int> RemoveAllCart(string username)
        {
            var Usercart = await db.ShoppingCart.Where(s => s.customer.UserName == username).ToListAsync();
            if (Usercart != null)
            {
                db.ShoppingCart.RemoveRange(Usercart);
                if (await db.SaveChangesAsync()>0)
                {
                    return 1;
                }
            }
            return 0;
        }

        public async Task<IEnumerable<ShoppingCart>> GetUserCart(string username)
        {
            var Usercart = await db.ShoppingCart.Include(p=>p.product).Where(s => s.customer.UserName == username).ToListAsync();
            if (Usercart != null)
            { return Usercart; }
             return null;
        }
        //public async Task<CartForReturn_Dto> GetCart()
        //{
        //    var CartForReturn = new CartForReturn_Dto();
        //    var cart = await _db.shoppingCarts.Include(p => p.product).Where(si => si.Shopping_Cart_Id == Shopping_Cart_Id).ToListAsync();// && si.User_ID == Helper.LoggedUserId
        //    List<CartList_Dto> cartList = new List<CartList_Dto>();
        //    foreach (var item in cart)
        //    {
        //        var cartListDto = new CartList_Dto
        //        {
        //            Amount = item.amount,
        //            CartId = item.Shopping_Cart_Id,
        //            Product_Id = item.product.Id,
        //            Price = item.product.Price,
        //            ProductImage = item.product.MainImageURL,
        //            ProductName = item.product.Name,
        //            Tota_Amount_Price = item.amount * item.product.Price
        //        };
        //        cartList.Add(cartListDto);

        //        CartForReturn = new CartForReturn_Dto
        //        {
        //            cartList = cartList,
        //            Shopping_Cart_Id = Shopping_Cart_Id,
        //            TotalPrice = (item.amount * item.product.Price) + (CartForReturn.TotalPrice),
        //            UserName = Helper.LoggedUserName
        //        };
        //    }
        //    return CartForReturn;
        //}












    }
}
