namespace MyNewsApi.Frontend.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedAt { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}