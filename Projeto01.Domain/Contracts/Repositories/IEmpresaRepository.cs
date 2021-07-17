﻿using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Domain.Contracts.Repositories
{
    public interface IEmpresaRepository : IBaseRepository<Empresa, Guid>
    {

    }
}
