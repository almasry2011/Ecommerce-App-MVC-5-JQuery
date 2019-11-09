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
    public class ProductsController : ApiController
    {
        IRepository<Product> _ProductsRepo;
        public ProductsController()
        {
            _ProductsRepo = new Products_Repository();
        }
        public async Task <IHttpActionResult>  GetProducts()
        {
         var Products=   await  _ProductsRepo.GetAll();
            return Ok(Products);
        }
        public async Task<IHttpActionResult> PostProducts([FromBody]Product Product)
        {
            var IsPosted =await _ProductsRepo.Add(Product);
            if (IsPosted>0)
            {
                return Ok(new { Status=1,Message="Successfully Created" }) ;
            }
            return BadRequest();
        }
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            var Product = await _ProductsRepo.GetById(id);
            return Ok(Product);
        }
        public async Task<IHttpActionResult> PutProducts(int id, [FromBody]Product Product)
        {
            var IsUpdated = await _ProductsRepo.Update(id, Product);
            if (IsUpdated>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
        public async Task<IHttpActionResult> Delete(int id)
        {
            var IsDeleted =await _ProductsRepo.Remove(id);
            if (IsDeleted>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
    }
}
