using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Projeto01.Infra.Data.MongoDB.Contexts;
using Projeto01.Infra.Data.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Configurations
{
    public class MongoDBSetup
    {
        public static void AddMongoDB(IServiceCollection services, IConfiguration configuration)
        {
            var settings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(settings);

            services.AddSingleton(settings);
            services.AddSingleton<MongoDBContext>();
        }
    }
}
