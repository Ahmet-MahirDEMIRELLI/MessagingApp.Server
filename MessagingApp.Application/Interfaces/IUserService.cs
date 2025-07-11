using MessagingApp.Application.DTOs;
using MessagingApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessagingApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByNicknameAsync(string nickname);
        Task<UserInformation?> GetKeysByNicknameAsync(string nickname);
        Task<User?> CreateUserAsync(CreateUserDto createUserDto);
    }
}
