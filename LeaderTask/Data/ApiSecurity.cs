using LeaderTask.Infrastructure;
using LeaderTask.Models;
using LeaderTask.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LeaderTask.Data
{
    public class ApiSecurity
    {
        public async static Task <bool> VaidateUser(string username, string password)
        {
            IRepository<Customer> _CustomerRepo = new Customer_Repository();
            var UserLists =await _CustomerRepo.GetAll();
           return UserLists.Any(user =>
              user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
             && user.Password == password);
        }

    }
}