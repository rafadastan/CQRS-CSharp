using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly SqlServerContext _context;

        protected BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public virtual void Create(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>()
                    .ToList();
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>()
                    .Where(where)
                    .ToList();
        }

        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>()
                    .Where(where)
                    .FirstOrDefault();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>()
                    .Find(id);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
