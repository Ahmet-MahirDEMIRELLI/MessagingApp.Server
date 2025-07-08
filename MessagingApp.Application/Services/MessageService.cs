using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using MessagingApp.Infrastructure.Interfaces;
using MessagingApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;
        private readonly ISignatureRepository _signatureRepository;

        public MessageService(IMessageRepository messageRepository, IUserService userService, ISignatureRepository signatureRepository)
        {
            _messageRepository = messageRepository;
            _userService = userService;
            _signatureRepository = signatureRepository;
        }

        public async Task<List<Message>> GetNewMessagesAsync(string nickname, String lastMessageTime)
        {
            return await _messageRepository.GetNewMessagesAsync(nickname, lastMessageTime);
        }

        public async Task<List<Message>> GetMessagesByNicknameAsync(string nickname)
        {
            return await _messageRepository.GetMessagesByNicknameAsync(nickname);
        }

        public async Task<Message> SendMessageAsync(SendMessageDto sendMessageDto)
        {
            var sender = await _userService.GetUserByNicknameAsync(sendMessageDto.Sender);
            if (sender == null)
            {
                return null;
            }

            var receiver = await _userService.GetUserByNicknameAsync(sendMessageDto.Receiver);
            if (receiver == null)
            {
                return null;
            }

            var message = new Message(sendMessageDto.Sender.ToLower(), sendMessageDto.Receiver.ToLower(), sendMessageDto.Content, DateTime.UtcNow.AddHours(3));
            string signedData = $"{message.Sender}|{message.Receiver}|{message.Content}";
            byte[] signatureBytes = Convert.FromBase64String(sendMessageDto.Signature);
            byte[] publicKeyBytes = Convert.FromBase64String(sender.Ed25519PublicKey);
            if (!_signatureRepository.Verify(signedData, signatureBytes, publicKeyBytes))
            {
                throw new SecurityException("İmza geçersiz.");
            }

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
            return message;
        }
    }
}
