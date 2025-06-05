using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetAsync(params object[] keyValues);

        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> SaveChangesAsync();
    }
}
