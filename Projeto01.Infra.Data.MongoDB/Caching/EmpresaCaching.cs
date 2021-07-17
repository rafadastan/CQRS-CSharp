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
    public class EmpresaCaching : IEmpresaCaching
    {
        private readonly MongoDBContext _context;

        public EmpresaCaching(MongoDBContext context)
        {
            _context = context;
        }

        public void Create(EmpresaModel model)
        {
            _context.Empresas.InsertOne(model);
        }

        public void Update(EmpresaModel model)
        {
            var filter = Builders<EmpresaModel>.Filter.Eq(e => e.Id, model.Id);
            _context.Empresas.ReplaceOne(filter, model);
        }

        public void Delete(EmpresaModel model)
        {
            var filter = Builders<EmpresaModel>.Filter.Eq(e => e.Id, model.Id);
            _context.Empresas.DeleteOne(filter);
        }

        public List<EmpresaModel> GetAll()
        {
            var filter = Builders<EmpresaModel>.Filter.Where(e => true);
            return _context.Empresas.Find(filter).ToList();
        }

        public EmpresaModel GetById(Guid id)
        {
            var filter = Builders<EmpresaModel>.Filter.Eq(e => e.Id, id);
            return _context.Empresas.Find(filter).FirstOrDefault();
        }
    }
}
