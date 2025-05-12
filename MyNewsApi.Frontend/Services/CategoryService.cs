using System.Net.Http.Json;
using MyNewsApi.Frontend.Models;

namespace MyNewsApi.Frontend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>("api/categories")
                   ?? new List<Category>();
        }

        public async Task CreateCategoryAsync(CategoryCreateDto categoryDto)
        {
            await _httpClient.PostAsJsonAsync("api/categories", categoryDto);
        }
    }
}