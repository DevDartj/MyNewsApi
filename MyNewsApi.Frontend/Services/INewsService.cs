using MyNewsApi.Frontend.Models;

namespace MyNewsApi.Frontend.Services
{
    public interface INewsService
    {
        Task<List<News>> GetNewsAsync();
        Task CreateNewsAsync(NewsDto newsDto);
    }
}