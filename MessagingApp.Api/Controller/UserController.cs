using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessagingApp.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{nickname}")]
        public async Task<IActionResult> GetByNickname(string nickname)
        {
            var user = await _userService.GetUserByNicknameAsync(nickname);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Nickname and PublicKey must not be empty.");

            var createdUser = await _userService.CreateUserAsync(createUserDto);

            if (createdUser == null)
                return BadRequest("Invalid nickname or user already exists.");

            return CreatedAtAction(nameof(GetByNickname), new { nickname = createdUser.Nickname }, createdUser);
        }

        [HttpPut("{nickname}")]
        public async Task<IActionResult> Update(string nickname, [FromBody] User user)
        {
            var updated = await _userService.UpdateUserAsync(nickname, user);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{nickname}")]
        public async Task<IActionResult> Delete(string nickname)
        {
            var deleted = await _userService.DeleteUserAsync(nickname);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
