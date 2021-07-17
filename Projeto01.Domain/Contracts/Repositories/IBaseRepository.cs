using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
        where TKey : struct
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity Get(Func<TEntity, bool> where);
        TEntity GetById(TKey id);
    }
}
