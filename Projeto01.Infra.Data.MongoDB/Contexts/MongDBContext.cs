using MongoDB.Driver;
using Projeto01.Domain.Models;
using Projeto01.Infra.Data.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.MongoDB.Contexts
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings _settings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(MongoDBSettings settings)
        {
            _settings = settings;
            Initialize();
        }

        //fazendo a conexão com o banco do MongoDB
        private void Initialize()
        {
            var client = MongoClientSettings.FromUrl(new MongoUrl(_settings.Host));

            if (_settings.IsSSL)
            {
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };
            }

            _mongoDatabase = new MongoClient(client).GetDatabase(_settings.Name);
        }

        //mapear as collections do mongodb
        public IMongoCollection<EmpresaModel> Empresas
            => _mongoDatabase.GetCollection<EmpresaModel>("Empresas");

        public IMongoCollection<FuncionarioModel> Funcionarios
            => _mongoDatabase.GetCollection<FuncionarioModel>("Funcionarios");
    }
}
