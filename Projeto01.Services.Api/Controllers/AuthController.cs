using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Commands.Usuarios;
using Projeto01.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public AuthController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(AuthenticationCommand command)
        {
            try
            {
                var accessToken = _usuarioApplicationService.Authenticate(command);

                if (accessToken != null)
                    return Ok(new
                    {
                        Mensagem = "Usuário autenticado com sucesso",
                        AccessToken = accessToken
                    });

                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}