using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingApp.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getMessagesByNickname/{nickname}")]
        public async Task<IActionResult> getMessagesByNickname(string nickname)
        {
            var messages = await _messageService.GetMessagesByNicknameAsync(nickname);
            return Ok(messages);
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> Create([FromBody] SendMessageDto sendMessageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Sender, Receiver and content must not be empty.");

            var message = await _messageService.SendMessageAsync(sendMessageDto);

            if (message == null)
                return BadRequest("Invalid sender or receiver nickname.");

            return Ok(message);
        }
    }
}
