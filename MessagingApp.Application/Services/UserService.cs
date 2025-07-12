using MessagingApp.Application.DTOs;
using MessagingApp.Application.Interfaces;
using MessagingApp.Domain.Entities;
using MessagingApp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByNicknameAsync(string nickname)
        {
            return await _userRepository.GetByNicknameAsync(nickname);
        }

        public async Task<UserInformation?> GetKeysByNicknameAsync(string nickname)
        {
            User? user = await _userRepository.GetKeysByNicknameAsync(nickname);
            if(user == null)
            {
                return null;
            }

            UserInformation userInformation = new UserInformation();
            userInformation.X25519PublicKey = user.X25519PublicKey;
            userInformation.Ed25519PublicKey = user.Ed25519PublicKey;
            return userInformation;

        }

        public async Task<User?> CreateUserAsync(CreateUserDto createUserDto)
        {
            createUserDto.Nickname = createUserDto.Nickname.ToLower();
            var existingUser = await GetUserByNicknameAsync(createUserDto.Nickname);
            if (existingUser != null)
            {
                return null;
            }

            var allowedUsers = new HashSet<string> { "amd", "nef", "nihal", "sukru" };
            if (!allowedUsers.Contains(createUserDto.Nickname))
            {
                return null;
            }

            var user = new User(createUserDto.Nickname, createUserDto.X25519PublicKey, createUserDto.Ed25519PublicKey, DateTime.UtcNow.AddHours(3));
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }
    }
}
