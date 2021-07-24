using AutoMapper;
using FluentValidation;
using MediatR;
using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Application.Notifications;
using Projeto01.Domain.Contracts.Services;
using Projeto01.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto01.Application.RequestHandlers
{
    public class FuncionarioRequestHandler :
        IRequestHandler<FuncionarioCreateCommand>,
        IRequestHandler<FuncionarioUpdateCommand>,
        IRequestHandler<FuncionarioDeleteCommand>,
        IDisposable
    {
        private readonly IFuncionarioDomainService _funcionarioDomainService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FuncionarioRequestHandler(IFuncionarioDomainService funcionarioDomainService, IMediator mediator, IMapper mapper)
        {
            _funcionarioDomainService = funcionarioDomainService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(FuncionarioCreateCommand request, CancellationToken cancellationToken)
        {
            #region Cadastrando funcionario

            var funcionario = _mapper.Map<Funcionario>(request);

            //executar a validação da entidade de dominio
            var result = funcionario.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _funcionarioDomainService.Create(funcionario);

            #endregion

            #region Gerar a notificação

            var notification = new FuncionarioNotification
            {
                Action = ActionNotification.Create,
                Funcionario = funcionario
            };

            await _mediator.Publish(notification); //FuncionarioHandler!

            #endregion

            return Unit.Value;
        }

        public async Task<Unit> Handle(FuncionarioUpdateCommand request, CancellationToken cancellationToken)
        {
            #region Atualizando funcionario

            var funcionario = _mapper.Map<Funcionario>(request);

            //executar a validação da entidade de dominio
            var result = funcionario.Validate;
            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            _funcionarioDomainService.Update(funcionario);

            #endregion

            #region Gerar a notificação

            var notification = new FuncionarioNotification
            {
                Action = ActionNotification.Update,
                Funcionario = funcionario
            };

            await _mediator.Publish(notification); //FuncionarioHandler!

            #endregion

            return Unit.Value;
        }

        public async Task<Unit> Handle(FuncionarioDeleteCommand request, CancellationToken cancellationToken)
        {
            #region Excluindo funcionario

            var funcionario = _mapper.Map<Funcionario>(request);
            _funcionarioDomainService.Delete(funcionario);

            #endregion

            #region Gerar a notificação

            var notification = new FuncionarioNotification
            {
                Action = ActionNotification.Delete,
                Funcionario = funcionario
            };

            await _mediator.Publish(notification); 

            #endregion

            return Unit.Value;
        }

        public void Dispose()
        {
            _funcionarioDomainService.Dispose();
        }
    }
}
