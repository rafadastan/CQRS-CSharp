using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Contracts
{
    public interface IFuncionarioApplicationService
    {
        Task Create(FuncionarioCreateCommand command);
        Task Update(FuncionarioUpdateCommand command);
        Task Delete(FuncionarioDeleteCommand command);

        List<FuncionarioModel> GetAll();
        FuncionarioModel GetById(Guid id);
    }
}
