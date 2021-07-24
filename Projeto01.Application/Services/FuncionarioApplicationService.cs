using MediatR;
using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Application.Contracts;
using Projeto01.Domain.Contracts.Caching;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly IMediator _mediator;
        private readonly IFuncionarioCaching _funcionarioCaching;

        public FuncionarioApplicationService(IMediator mediator, IFuncionarioCaching funcionarioCaching)
        {
            _mediator = mediator;
            _funcionarioCaching = funcionarioCaching;
        }

        public async Task Create(FuncionarioCreateCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task Update(FuncionarioUpdateCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task Delete(FuncionarioDeleteCommand command)
        {
            await _mediator.Send(command);
        }

        public List<FuncionarioModel> GetAll()
        {
            return _funcionarioCaching.GetAll();
        }

        public FuncionarioModel GetById(Guid id)
        {
            return _funcionarioCaching.GetById(id);
        }
    }
}
