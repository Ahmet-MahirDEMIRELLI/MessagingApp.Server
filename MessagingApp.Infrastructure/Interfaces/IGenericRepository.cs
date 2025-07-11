using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task<bool> SaveChangesAsync();
    }
}
