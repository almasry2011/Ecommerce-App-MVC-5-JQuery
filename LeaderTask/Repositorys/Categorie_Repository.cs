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
    public class CategorieRepository : IRepository<Category>
    {
        TaskContext db;
        public CategorieRepository()
        {
            db = new TaskContext();
        }
        public async Task<int> Add(Category entity)
        {
            db.Categories.Add(entity);
            return await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            var cat = await db.Categories.ToListAsync();
            return cat;
        }
        public async Task<Category> GetById(int id)
        {
            var cat = await db.Categories.Include(p => p.Products).SingleOrDefaultAsync(c => c.CategoryId == id);
            return cat;
        }
        public async Task<int> Remove(int id)
        {
            var cat = await GetById(id);
            if (cat!=null)
            {
                db.Categories.Remove(cat);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Update(int id, Category NewCat)
        {
            var OldCat = await GetById(id);
            OldCat.CategoryName = NewCat.CategoryName;
            return await db.SaveChangesAsync();
        }
    }
}
