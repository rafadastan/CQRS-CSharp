using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Services
{
    public interface IEmpresaDomainService 
        : IBaseDomainService<Empresa, Guid>
    {

    }
}
