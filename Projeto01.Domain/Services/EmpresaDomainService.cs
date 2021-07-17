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
    public class EmpresaDomainService : BaseDomainService<Empresa, Guid>, IEmpresaDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.EmpresaRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
