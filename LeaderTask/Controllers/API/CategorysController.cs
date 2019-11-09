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
    public class CategorysController : ApiController
    {
        IRepository<Category> _CategorysRepo;
        public CategorysController()
        {
            _CategorysRepo = new CategorieRepository();
        }
        public async Task <IHttpActionResult>  GetCategorys()
        {
         var Categorys=   await  _CategorysRepo.GetAll();
            return Ok(Categorys);
        }
        public async Task<IHttpActionResult> PostCategorys([FromBody]Category Category)
        {
            var IsPosted =await _CategorysRepo.Add(Category);
            if (IsPosted>0)
            {
                return Ok(new { Status=1,Message="Successfully Created" }) ;
            }
            return BadRequest();
        }
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            var Category = await _CategorysRepo.GetById(id);
            return Ok(Category);
        }
        public async Task<IHttpActionResult> PutCategorys(int id, [FromBody]Category Category)
        {
            var IsUpdated = await _CategorysRepo.Update(id, Category);
            if (IsUpdated>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
        public async Task<IHttpActionResult> Delete(int id)
        {
            var IsDeleted =await _CategorysRepo.Remove(id);
            if (IsDeleted>0)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return StatusCode(HttpStatusCode.BadRequest);

        }
    }
}
