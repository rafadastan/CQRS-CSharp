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
    public class FuncionarioRepository : BaseRepository<Funcionario, Guid>, IFuncionarioRepository
    {
        private readonly SqlServerContext _context;

        public FuncionarioRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
