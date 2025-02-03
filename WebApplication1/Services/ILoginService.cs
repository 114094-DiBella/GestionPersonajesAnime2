using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUserAsync(string username, string password);
        Task<Usuario> RegisterUserAsync(string username, string password, string email);
        Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
        Task<Usuario> GetUserByUsernameAsync(string username);
    }
}
