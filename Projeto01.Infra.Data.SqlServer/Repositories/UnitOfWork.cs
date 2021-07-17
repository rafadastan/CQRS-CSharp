using Microsoft.EntityFrameworkCore.Storage;
using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public IEmpresaRepository EmpresaRepository => new EmpresaRepository(_context);

        public IFuncionarioRepository FuncionarioRepository => new FuncionarioRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
