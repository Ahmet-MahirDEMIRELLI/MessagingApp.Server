using MessagingApp.Domain.Entities;
using MessagingApp.Infrastructure.Interfaces;
using MessagingApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessagingApp.Infrastructure.Persistence;

namespace MessagingApp.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByNicknameAsync(string nickname)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }

        public async Task<User?> GetKeysByNicknameAsync(string nickname)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }
    }
}
