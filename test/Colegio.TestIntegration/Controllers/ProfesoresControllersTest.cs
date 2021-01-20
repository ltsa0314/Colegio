
using Colegio.Api;
using Colegio.Domain.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Colegio.TestIntegration.Controllers
{
    public class ProfesoresControllersTest
    {
        [Fact]
        public void GetAll()
        {
            // Arrange
            TestServer server;
            HttpClient client;

            server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>().UseEnvironment("Integration"));
            client =  server.CreateClient();

            // Act
            var result = client.GetAsync($"api/profesores").Result;
            List<ProfesorEntity> profesores = null;

            if (result.StatusCode == HttpStatusCode.OK)
            {
                profesores = JsonConvert.DeserializeObject<List<ProfesorEntity>>(result.Content.ReadAsStringAsync().Result);
            }

            // Assert
            Assert.True(result.StatusCode == HttpStatusCode.OK);
            Assert.True(profesores != null);
            Assert.True(profesores.Count == 0);
        }
    }
}
