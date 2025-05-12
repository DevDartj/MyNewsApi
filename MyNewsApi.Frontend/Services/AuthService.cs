using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using MyNewsApi.Frontend.Models;

namespace MyNewsApi.Frontend.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _storage;

        public AuthService(HttpClient http, ILocalStorageService storage)
        {
            _http = http;
            _storage = storage;
        }

        public async Task<AuthResult> LoginAsync(LoginDto loginDto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", loginDto);
            if (!response.IsSuccessStatusCode)
            {
                var err = await response.Content.ReadAsStringAsync();
                return new AuthResult { IsSuccess = false, Error = err };
            }

            var result = await response.Content
                                       .ReadFromJsonAsync<AuthResult>()
                         ?? new AuthResult { IsSuccess = false, Error = "Invalid server response" };

            if (result.IsSuccess && !string.IsNullOrWhiteSpace(result.Token))
            {
                // 1) Salvo il token in LocalStorage
                await _storage.SetItemAsync("authToken", result.Token);

                // 2) Imposto l'header per le chiamate future
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", result.Token);
            }

            return result;
        }

        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/register", registerDto);
            return response.IsSuccessStatusCode;
        }

        public Task LogoutAsync()
        {
            // Rimuovo il token e tolgo l'header
            _storage.RemoveItemAsync("authToken");
            _http.DefaultRequestHeaders.Authorization = null;
            return Task.CompletedTask;
        }

        public async Task<string?> GetTokenAsync()
            => await _storage.GetItemAsync<string>("authToken");
    }
}