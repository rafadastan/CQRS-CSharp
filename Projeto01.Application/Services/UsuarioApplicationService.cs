using Projeto01.Application.Commands.Usuarios;
using Projeto01.Application.Contracts;
using Projeto01.Security.Authentication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly AccessTokenService _acessTokenService;
        public UsuarioApplicationService(AccessTokenService acessTokenService)
        {
            _acessTokenService = acessTokenService;
        }

        public string Authenticate(AuthenticationCommand command)
        {
            if ("admin@gmail.com".Equals(command.Email) && "adminadmin".Equals(command.Senha))
            {
                return _acessTokenService.GenerateToken(command.Email);
            }

            return null;
        }
    }
}
