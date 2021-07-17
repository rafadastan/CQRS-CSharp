using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Commands.Usuarios
{
    public class AuthenticationCommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
