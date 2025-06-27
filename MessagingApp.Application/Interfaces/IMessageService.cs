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
        Task<Message> SendMessageAsync(SendMessageDto sendMessageDto);
        Task<List<Message>> GetMessagesByNicknameAsync(String nickname);
    }
}
