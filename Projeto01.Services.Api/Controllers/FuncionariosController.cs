using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Adapters.ValidationErrors;
using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioApplicationService _funcionarioApplicationService;

        public FuncionariosController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            _funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FuncionarioCreateCommand command)
        {
            try
            {
                await _funcionarioApplicationService.Create(command);
                return StatusCode(201, new { Message = "Funcionário cadastrado com sucesso." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationErrorAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(FuncionarioUpdateCommand command)
        {
            try
            {
                await _funcionarioApplicationService.Update(command);
                return Ok(new { Message = "Funcionário atualizado com sucesso." });
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationErrorAdapter.Parse(e.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new FuncionarioDeleteCommand { Id = id };

                await _funcionarioApplicationService.Delete(command);
                return Ok(new { Message = "Funcionário excluido com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _funcionarioApplicationService.GetAll();

                if (result.Count == 0)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var result = _funcionarioApplicationService.GetById(id);

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
