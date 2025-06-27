using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using MessagingApp.Infrastructure.Interfaces;
using MessagingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        public MessageService(IMessageRepository messageRepository, IUserService userService)
        {
            _messageRepository = messageRepository;
            _userService = userService;
        }

        public async Task<Message> SendMessageAsync(SendMessageDto sendMessageDto)
        {
            var existingUser = await _userService.GetUserByNicknameAsync(sendMessageDto.Sender);
            if (existingUser == null)
            {
                return null;
            }

            existingUser = await _userService.GetUserByNicknameAsync(sendMessageDto.Receiver);
            if (existingUser == null)
            {
                return null;
            }

            var message = new Message(sendMessageDto.Sender, sendMessageDto.Receiver, sendMessageDto.Content, DateTime.UtcNow);
            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
            return message;
        }

        public async Task<List<Message>> GetMessagesByNicknameAsync(string nickname)
        {
            return await _messageRepository.GetMessagesByNicknameAsync(nickname);
        }
    }
}
