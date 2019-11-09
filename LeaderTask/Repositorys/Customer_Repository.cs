using LeaderTask.Data;
using LeaderTask.Infrastructure;
using LeaderTask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LeaderTask.Repositorys
{
    public class Customer_Repository : IRepository<Customer>
    {
        TaskContext db;
        public Customer_Repository()
        {
            db = new TaskContext();
        }
        public async Task<int> Add(Customer entity)
        {
            db.Customers.Add(entity);
            return await db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var cust = await db.Customers.ToListAsync();
            return cust;
        }
        public async Task<Customer> GetById(int id)
        {
            var cust = await db.Customers.SingleOrDefaultAsync(c => c.CustomerID == id);
            return cust;
        }
        public async Task<int> Remove(int id)
        {
            var customer = await GetById(id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                return await db.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Update(int id , Customer NewCust)
        {
            var OldCust =await GetById(id);
            OldCust.CustomerName = NewCust.CustomerName;
            OldCust.Email = NewCust.Email;
            OldCust.Country = NewCust.Country;
            OldCust.Image = NewCust.Image;
            OldCust.Phone = NewCust.Phone;
            return await db.SaveChangesAsync();
        }
    }
}