using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderTask.Infrastructure
{
    interface IRepository<TEntity>
    {
        Task<int> Add(TEntity entity);
        Task<int> Update(int id,TEntity entity);
        Task<int> Remove(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
