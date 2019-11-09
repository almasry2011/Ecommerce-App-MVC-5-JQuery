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
    public class Products_Repository : IRepository<Product>
    {
        TaskContext db;
        public Products_Repository()
        {
            db = new TaskContext();
        }
        public async Task<int> Add(Product entity)
        {
            db.Products.Add(entity);
            return await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            var Prod = await db.Products.Include(c=>c.category).ToListAsync();
            return Prod;
        }
        public async Task<Product> GetById(int id)
        {
            var Prod = await db.Products.SingleOrDefaultAsync(c => c.ProductID == id);
            return Prod;
        }
        public async Task<int> Remove(int id)
        {
            var Prod = await GetById(id);
            if (Prod != null)
            {
                db.Products.Remove(Prod);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Update(int id, Product NewProd)
        {
            var OldProd = await GetById(id);
            OldProd.ProductName = NewProd.ProductName;
            OldProd.UnitPrice = NewProd.UnitPrice;
            OldProd.UnitsInStock = NewProd.UnitsInStock;
            OldProd.CategoryId = NewProd.CategoryId;
            OldProd.Image = NewProd.Image;
            return await db.SaveChangesAsync();
        }
    }
}
