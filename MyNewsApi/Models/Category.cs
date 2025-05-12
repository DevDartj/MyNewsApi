using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyNewsApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string ? Name { get; set; }

        public string? Description { get; set; }

        // Relazione 1 a n: una categoria può avere molte notizie
        public ICollection<News> NewsItems { get; set; } = new List<News>();
    }
}