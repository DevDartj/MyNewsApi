using System.ComponentModel.DataAnnotations;

namespace MyNewsApi.Frontend.Models
{
    public class NewsDto
    {
        [Required(ErrorMessage = "Il titolo è obbligatorio")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Il contenuto è obbligatorio")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleziona una categoria")]
        public int CategoryId { get; set; }
    }
}