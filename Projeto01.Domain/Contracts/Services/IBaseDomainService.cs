using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity, TKey> : IDisposable
        where TEntity : class
        where TKey : struct
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        TEntity GetById(TKey id);
    }
}
