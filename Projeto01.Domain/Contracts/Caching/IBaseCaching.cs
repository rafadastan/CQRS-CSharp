using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Caching
{
    public interface IBaseCaching<TModel, TKey>
        where TModel : class
        where TKey : struct
    {
        void Create(TModel entity);
        void Update(TModel entity);
        void Delete(TModel entity);

        List<TModel> GetAll();
        TModel GetById(TKey id);
    }
}
