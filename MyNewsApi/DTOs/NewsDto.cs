namespace MyNewsApi.DTOs
{
    public class NewsDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public int CategoryId { get; set; } 
    }
}