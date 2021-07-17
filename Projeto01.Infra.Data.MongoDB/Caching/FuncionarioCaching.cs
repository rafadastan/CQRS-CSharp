using MongoDB.Driver;
using Projeto01.Domain.Contracts.Caching;
using Projeto01.Domain.Models;
using Projeto01.Infra.Data.MongoDB.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.MongoDB.Caching
{
    public class FuncionarioCaching : IFuncionarioCaching
    {
        private readonly MongoDBContext _context;

        public FuncionarioCaching(MongoDBContext context)
        {
            _context = context;
        }

        public void Create(FuncionarioModel model)
        {
            _context.Funcionarios.InsertOne(model);
        }

        public void Update(FuncionarioModel model)
        {
            var filter = Builders<FuncionarioModel>.Filter.Eq(e => e.Id, model.Id);
            _context.Funcionarios.ReplaceOne(filter, model);
        }

        public void Delete(FuncionarioModel model)
        {
            var filter = Builders<FuncionarioModel>.Filter.Eq(e => e.Id, model.Id);
            _context.Funcionarios.DeleteOne(filter);
        }

        public List<FuncionarioModel> GetAll()
        {
            var filter = Builders<FuncionarioModel>.Filter.Where(e => true);
            return _context.Funcionarios.Find(filter).ToList();
        }

        public FuncionarioModel GetById(Guid id)
        {
            var filter = Builders<FuncionarioModel>.Filter.Eq(e => e.Id, id);
            return _context.Funcionarios.Find(filter).FirstOrDefault();
        }
    }
}
