using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IBaseRepository<TEntity, TKey> _repository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            _repository.Create(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
