using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MyNewsApi; // Assicurati che il namespace corrisponda a quello del progetto backend
using Xunit;

namespace MyNewsApi.Tests.IntegrationTests
{
    public class NewsApiTests : IntegrationTest
    {
        public NewsApiTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task GetAllNews_ReturnsOk()
        {
            // Esegue la chiamata GET a /api/news
            var response = await _client.GetAsync("/api/news");

            // Verifica che lo status code sia 200 OK
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        // Puoi aggiungere ulteriori test per POST, PUT e DELETE se necessario.
    }
}