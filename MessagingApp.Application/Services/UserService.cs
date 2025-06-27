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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
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
            var existingUser = await GetUserByNicknameAsync(createUserDto.Nickname);
            if (existingUser != null)
            {
                return null;
            }

            var user = new User(createUserDto.Nickname, createUserDto.X25519PublicKey, createUserDto.Ed25519PublicKey, DateTime.UtcNow, DateTime.UtcNow);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(string nickname, User user)
        {
            var existingUser = await _userRepository.GetByNicknameAsync(nickname);
            if (existingUser == null)
                return false;

            // Güncellenebilir alanlar
            existingUser.X25519PublicKey = user.X25519PublicKey;
            existingUser.Ed25519PublicKey = user.Ed25519PublicKey;
            existingUser.LastActivityDate = DateTime.UtcNow;

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteUserAsync(string nickname)
        {
            var user = await _userRepository.GetByNicknameAsync(nickname);
            if (user == null)
                return false;

            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }
    }
}
