using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Tests.Helpers
{
    public class HttpClientHelper
    {
        public static HttpClient Create()
        {
            #region Iniciaizando o projeto API

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Services.Api.Startup>());

            #endregion

            return server.CreateClient();
        }
    }
}
