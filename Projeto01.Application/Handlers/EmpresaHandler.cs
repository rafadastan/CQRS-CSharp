using AutoMapper;
using MediatR;
using Projeto01.Application.Notifications;
using Projeto01.Domain.Contracts.Caching;
using Projeto01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto01.Application.Handlers
{
    public class EmpresaHandler : INotificationHandler<EmpresaNotification>
    {
        private readonly IEmpresaCaching _empresaCaching;
        private readonly IMapper _mapper;

        public EmpresaHandler(IEmpresaCaching empresaCaching, IMapper mapper)
        {
            _empresaCaching = empresaCaching;
            _mapper = mapper;
        }

        public Task Handle(EmpresaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var model = _mapper.Map<EmpresaModel>(notification.Empresa);

                switch (notification.Action)
                {
                    case ActionNotification.Create:
                        _empresaCaching.Create(model);
                        break;

                    case ActionNotification.Update:
                        _empresaCaching.Update(model);
                        break;

                    case ActionNotification.Delete:
                        _empresaCaching.Delete(model);
                        break;
                }
            });
        }
    }
}
