using Projeto01.Domain.Entities;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Caching
{
    public interface IFuncionarioCaching : IBaseCaching<FuncionarioModel, Guid>
    {

    }
}
