// File: Models/AuthResult.cs
namespace MyNewsApi.Frontend.Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
    }
}