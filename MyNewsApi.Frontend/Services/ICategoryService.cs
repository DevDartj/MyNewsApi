using MyNewsApi.Frontend.Models;

namespace MyNewsApi.Frontend.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task CreateCategoryAsync(CategoryCreateDto categoryDto);
    }
}