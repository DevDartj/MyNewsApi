using MyNewsApi.Frontend.Models;
using System.Threading.Tasks;

namespace MyNewsApi.Frontend.Services
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(LoginDto loginDto);
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task LogoutAsync();
        Task<string?> GetTokenAsync();
    }
}