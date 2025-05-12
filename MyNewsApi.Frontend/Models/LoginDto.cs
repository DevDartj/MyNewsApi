// File: Models/LoginDto.cs
using System.ComponentModel.DataAnnotations;

namespace MyNewsApi.Frontend.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email obbligatoria")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password obbligatoria")]
        public string Password { get; set; } = string.Empty;
    }
}