using System.Net.Http.Json;
using MyNewsApi.Frontend.Models;

namespace MyNewsApi.Frontend.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthService _authService;

        public NewsService(HttpClient httpClient, IAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<News>> GetNewsAsync()
        {
            // Recupera il token dal servizio di autenticazione
            var token = await _authService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            // Effettua la richiesta all'endpoint /api/news
            var response = await _httpClient.GetAsync("api/news");
            response.EnsureSuccessStatusCode();

            // Deserializza la risposta JSON in una lista di News
            var newsList = await response.Content.ReadFromJsonAsync<List<News>>();
            return newsList ?? new List<News>();
        }

        public async Task CreateNewsAsync(NewsDto newsDto)
        {
            // Recupera il token e lo aggiunge all'header della richiesta
            var token = await _authService.GetTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            // Effettua la richiesta POST per creare una nuova notizia
            var response = await _httpClient.PostAsJsonAsync("api/news", newsDto);
            response.EnsureSuccessStatusCode();
        }
    }
}