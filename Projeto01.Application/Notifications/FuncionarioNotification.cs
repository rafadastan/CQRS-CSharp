using MediatR;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Notifications
{
    public class FuncionarioNotification : INotification
    {
        public Funcionario Funcionario { get; set; }
        public ActionNotification Action { get; set; }
    }
}
