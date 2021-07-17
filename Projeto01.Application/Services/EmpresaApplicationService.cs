using MediatR;
using Projeto01.Application.Commands.Empresas;
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
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IMediator _mediator;
        private readonly IEmpresaCaching _empresaCaching;

        public EmpresaApplicationService(IMediator mediator,
            IEmpresaCaching empresaCaching)
        {
            _mediator = mediator;
            _empresaCaching = empresaCaching;
        }

        public async Task Create(EmpresaCreateCommand command)
        {
            await _mediator.Send(command); //EmpresaRequestHandler!
        }

        public async Task Update(EmpresaUpdateCommand command)
        {
            await _mediator.Send(command); //EmpresaRequestHandler!
        }

        public async Task Delete(EmpresaDeleteCommand command)
        {
            await _mediator.Send(command); //EmpresaRequestHandler!
        }

        public List<EmpresaModel> GetAll()
        {
            return _empresaCaching.GetAll();
        }

        public EmpresaModel GetById(Guid id)
        {
            return _empresaCaching.GetById(id);
        }
    }
}
