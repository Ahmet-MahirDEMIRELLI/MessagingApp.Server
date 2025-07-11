using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
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

        [HttpGet("getKeysByNickname/{nickname}")]
        public async Task<IActionResult> GetKeysByNickname(string nickname)
        {
            var userInformation = await _userService.GetKeysByNicknameAsync(nickname);
            if (userInformation == null)
                return NotFound();

            return Ok(userInformation);
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Nickname and PublicKeys must not be empty.");

            var createdUser = await _userService.CreateUserAsync(createUserDto);

            if (createdUser == null)
                return BadRequest("Invalid nickname or user already exists.");

            return CreatedAtAction(nameof(GetKeysByNickname), new { nickname = createdUser.Nickname }, createdUser);
        }      
    }
}
