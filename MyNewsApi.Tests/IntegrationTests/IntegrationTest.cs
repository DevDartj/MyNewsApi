using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using MyNewsApi; // Assicurati di utilizzare il namespace corretto per Program
using Xunit;

namespace MyNewsApi.Tests.IntegrationTests
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;

        public IntegrationTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }
    }
}