using MessagingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByNicknameAsync(string nickname);
        Task<User?> GetKeysByNicknameAsync(string nickname);
    }

}
