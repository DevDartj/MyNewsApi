using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MyNewsApi; // Verifica il namespace del progetto backend
using Xunit;

namespace MyNewsApi.Tests.IntegrationTests
{
    public class AuthApiTests : IntegrationTest
    {
        public AuthApiTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task RegisterUser_ReturnsCreatedOrOk()
        {
            // Dati per la registrazione
            var registerModel = new
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                Password = "Test@1234",
                ConfirmPassword = "Test@1234"
            };

            // Invio della richiesta POST per la registrazione
            var response = await _client.PostAsJsonAsync("/api/account/register", registerModel);

            // Verifica che lo status code sia Created (201) o OK (200)
            Assert.True(response.StatusCode == HttpStatusCode.Created ||
                        response.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task LoginUser_ReturnsOk()
        {
            // Dati per il login
            var loginModel = new
            {
                UserName = "testuser",
                Password = "Test@1234"
            };

            // Invio della richiesta POST per il login
            var response = await _client.PostAsJsonAsync("/api/account/login", loginModel);

            // Verifica che il login restituisca 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}