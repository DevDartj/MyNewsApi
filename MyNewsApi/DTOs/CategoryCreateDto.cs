namespace MyNewsApi.DTOs
{
    public class CategoryCreateDto
    {
        // Da inviare nel POST per creare una nuova categoria
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}