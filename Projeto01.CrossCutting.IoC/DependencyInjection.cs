using Microsoft.Extensions.DependencyInjection;
using Projeto01.Application.Contracts;
using Projeto01.Application.Services;
using Projeto01.Domain.Contracts.Caching;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Services;
using Projeto01.Infra.Data.MongoDB.Caching;
using Projeto01.Infra.Data.SqlServer.Repositories;
using System;

namespace Projeto01.CrossCutting.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IEmpresaApplicationService, EmpresaApplicationService>();
            services.AddTransient<IFuncionarioApplicationService, FuncionarioApplicationService>();
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

            #endregion

            #region InfraStructure SqlServer

            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion

            #region InfraStructure MongoDB

            services.AddTransient<IEmpresaCaching, EmpresaCaching>();
            services.AddTransient<IFuncionarioCaching, FuncionarioCaching>();

            #endregion
        }
    }
}
