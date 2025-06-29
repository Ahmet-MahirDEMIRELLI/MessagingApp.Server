using MessagingApp.Domain.Entities;

namespace MessagingApp.Infrastructure.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<List<Message>?> GetNewMessagesAsync(String nickname, String lastMessageTime);
        Task<List<Message>?> GetMessagesByNicknameAsync(string nickname);
    }
}
