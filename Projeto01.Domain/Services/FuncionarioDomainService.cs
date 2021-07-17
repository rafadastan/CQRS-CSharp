using Projeto01.Domain.Contracts.Repositories;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario, Guid>, IFuncionarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuncionarioDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.FuncionarioRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
