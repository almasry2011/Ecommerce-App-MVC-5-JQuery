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
    [BasicAuthentication]
    public class CustomersController : ApiController
    {
        IRepository<Customer> _CustomerRepo;
        public CustomersController()
        {
            _CustomerRepo = new Customer_Repository();
        }
        public async Task <IHttpActionResult>  GetCustomers()
        {
         var customers=   await  _CustomerRepo.GetAll();
            return Ok(customers);
        }
        // POST: api/Customers
        public async Task<IHttpActionResult> PostCustomers([FromBody]Customer customer)
        {
            var IsPosted =await _CustomerRepo.Add(customer);
            if (IsPosted>0)
            {
                return Ok(new { Status=1,Message="Successfully Created" }) ;
            }
            return BadRequest();
        }

        // GET: api/Customers/5
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            var customer = await _CustomerRepo.GetById(id);
            return Ok(customer);
        }



        // PUT: api/Customers/5
        public async Task<IHttpActionResult> PutCustomers(int id, [FromBody]Customer customer)
        {
            var IsUpdated = await _CustomerRepo.Update(id, customer);
            if (IsUpdated>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
        public async Task<IHttpActionResult> Delete(int id)
        {
            var IsDeleted =await _CustomerRepo.Remove(id);
            if (IsDeleted>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
    }
}
