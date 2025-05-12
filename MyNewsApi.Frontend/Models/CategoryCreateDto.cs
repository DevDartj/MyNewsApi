using System.ComponentModel.DataAnnotations;

namespace MyNewsApi.Frontend.Models
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        public string Description { get; set; } = string.Empty;
    }
}