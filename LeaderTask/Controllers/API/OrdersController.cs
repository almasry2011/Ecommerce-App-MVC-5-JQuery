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
    public class OrdersController : ApiController
    {
        //  IRepository<Order> _OrdersRepo; 
        Orders_Repo _OrdersRepo;
        public OrdersController()
        {
             _OrdersRepo = new Orders_Repo();
        }
        public async Task <IHttpActionResult>  GetOrders()
        {
         var Orders=    await  _OrdersRepo.GetAllOrders();
            return Ok(Orders);
        }

        public async Task<IHttpActionResult> GetOrder(int id)
        {
            var Order = await _OrdersRepo.GetOrder(id);
            return Ok(Order);
        }





        public async Task<IHttpActionResult> PostOrders([FromBody]Order Order,string username)
        {
            var IsPosted =await _OrdersRepo.Add(Order,username);
            if (IsPosted>0)
            {
                return Ok(new { Status=1,Message="Successfully Created" }) ;
            }
            return BadRequest();
        }
   
        //public async Task<IHttpActionResult> PutOrders(int id, [FromBody]Order Order)
        //{
        //    var IsUpdated = await _OrdersRepo.Update(id, Order);
        //    if (IsUpdated>0)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return StatusCode(HttpStatusCode.BadRequest);

        //}
        //public async Task<IHttpActionResult> Delete(int id)
        //{
        //    var IsDeleted =await _OrdersRepo.Remove(id);
        //    if (IsDeleted>0)
        //    {
        //        return StatusCode(HttpStatusCode.NoContent);
        //    }
        //    return StatusCode(HttpStatusCode.BadRequest);

        //}
    }
}
