using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Configurations
{
    public static class EntityFrameworkSetup
    {
        public static void AddEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Projeto01")));
        }
    }
}
