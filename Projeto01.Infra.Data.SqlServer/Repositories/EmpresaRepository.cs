using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa, Guid>, IEmpresaRepository
    {
        private readonly SqlServerContext _context;

        public EmpresaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
