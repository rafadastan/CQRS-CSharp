using AutoMapper;
using MediatR;
using Projeto01.Application.Notifications;
using Projeto01.Domain.Contracts.Caching;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto01.Application.Handlers
{
    public class FuncionarioHandler : INotificationHandler<FuncionarioNotification>
    {
        private readonly IFuncionarioCaching _funcionarioCaching;
        private readonly IMapper _mapper;

        public FuncionarioHandler(IFuncionarioCaching funcionarioCaching, IMapper mapper)
        {
            _funcionarioCaching = funcionarioCaching;
            _mapper = mapper;
        }

        public Task Handle(FuncionarioNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var model = _mapper.Map<FuncionarioModel>(notification.Funcionario);

                switch (notification.Action)
                {
                    case ActionNotification.Create:
                        _funcionarioCaching.Create(model);
                        break;

                    case ActionNotification.Update:
                        _funcionarioCaching.Update(model);
                        break;

                    case ActionNotification.Delete:
                        _funcionarioCaching.Delete(model);
                        break;
                }
            });
        }
    }
}
