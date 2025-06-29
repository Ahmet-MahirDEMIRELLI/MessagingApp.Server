using MessagingApp.Domain.Entities;
using MessagingApp.Infrastructure.Interfaces;
using MessagingApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Message>?> GetNewMessagesAsync(string nickname, string lastMessageTime)
        {
            if (!DateTime.TryParse(lastMessageTime, out DateTime parsedTime))
                return null;
            
            return await _dbSet
                .Where(m => m.Receiver == nickname && m.Timestamp > parsedTime)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task<List<Message>?> GetMessagesByNicknameAsync(string nickname)
        {
            return await _dbSet.Where(m => m.Receiver == nickname).ToListAsync();
        }
    }
}
