using Projeto01.Application.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        string Authenticate(AuthenticationCommand command);
    }
}
