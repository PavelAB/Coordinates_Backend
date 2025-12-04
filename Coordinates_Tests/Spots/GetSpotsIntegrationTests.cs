using Coordinates_Tests.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Coordinates_API;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates_Tests.Spots
{
    public class GetSpotsIntegrationTests: IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public GetSpotsIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetSpots_ReturnsOk()
        {
            var response = await _client.GetAsync("/api/Spot/GetSpots");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetSpots_ReturnsNotFound()
        {
            var response = await _client.GetAsync("/api/Spot/GetSpotss");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetSpots_ReturnsBadRequest()
        {
            var response = await _client.GetAsync("/api/Spot/GetSpots?idSpot=1");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetSpots_ReturnsBadRequestTEST()
        {
            var response = await _client.GetAsync("/api/Spot/GetSpots?idSpot=B4155jhghghgu88-BF9E-081E3A611FB1");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetSpots_ReturnsBadParams()
        {
            var response = await _client.GetAsync("/api/Spot/GetSpots?test");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]      
        public async Task GetSpots_ReturnsUnauthorized_WithoutAuth()
        {
            using var factory = new WebApplicationFactory<Program>();
            using var client = factory.CreateClient();


            var response = await client.GetAsync("/api/Spot/GetSpots");


            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
