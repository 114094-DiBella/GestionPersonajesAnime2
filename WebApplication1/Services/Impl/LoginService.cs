using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services.Impl
{
    public class LoginService : ILoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || oldPassword == null)
                return false;

            user.Password = newPassword;
            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<Usuario> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<Usuario> RegisterUserAsync(string username, string password, string email)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(username);
            if (existingUser != null)
                throw new InvalidOperationException("Username already exists");

            var newUser = new Usuario
            {
                Username = username,
                Password = password,
                Email = email
            };

            return await _userRepository.CreateAsync(newUser);
        }

        public async Task<Usuario> ValidateUserAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null || password == null)
                return null;

            return user;
        }
    }
}
