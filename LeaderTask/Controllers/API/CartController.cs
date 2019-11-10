using LeaderTask.Infrastructure;
using LeaderTask.Models;
using LeaderTask.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LeaderTask.Controllers.API
{
    public class CartController : ApiController
    {
        IRepository<Product> _ProductsRepo;

        Cart_Repository _crtRepo;
        public CartController()
        {
            _crtRepo = new Cart_Repository();
            _ProductsRepo = new Products_Repository();
        }
        [HttpPost]
        public async Task<IHttpActionResult> Add_RemoveToCart(int  ProductId, int amount, string username)
        {
            var product = await _ProductsRepo.GetById(ProductId);
            var IsAdded=  await  _crtRepo.Add_RemoveToCart(product, amount, username);
            if (IsAdded > 0)
            {
                return Ok(new { Status = 1, Message = "Success" });
            }
            return BadRequest();
        }
        public async Task<IHttpActionResult> RemoveUserCart(string username)
        {
            var usrcart =await _crtRepo.GetUserCart(username);
            if (usrcart!=null&&usrcart.Count()>0)
            {
                return Ok(usrcart);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetCart(string username)
        {
         var usrcart=  await  _crtRepo.GetUserCart(username);
            if (usrcart!=null&&usrcart.Count()>0)
            {
                return Ok(usrcart);
            }
            return NotFound();
        }
        }
}
