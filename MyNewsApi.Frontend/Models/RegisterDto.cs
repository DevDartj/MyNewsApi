// File: Models/RegisterDto.cs
using System.ComponentModel.DataAnnotations;

namespace MyNewsApi.Frontend.Models
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Nome obbligatorio")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Cognome obbligatorio")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email obbligatoria")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password obbligatoria")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Conferma password obbligatoria")]
        [Compare("Password", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}