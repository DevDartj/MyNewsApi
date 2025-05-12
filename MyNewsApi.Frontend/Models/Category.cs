namespace MyNewsApi.Frontend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    // Inizializzato per evitare warning
        public string Description { get; set; } = string.Empty;
    }
}