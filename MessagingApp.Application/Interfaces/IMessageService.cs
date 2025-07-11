using MessagingApp.Application.DTOs;
using MessagingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>?> GetMessagesByNicknameAsync(String nickname);
        Task<List<Message>?> GetNewMessagesAsync(String nickname, String lastMessageTime);
        Task<Message?> SendMessageAsync(SendMessageDto sendMessageDto);
    }
}
