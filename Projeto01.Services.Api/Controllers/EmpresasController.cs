using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto01.Application.Adapters.ValidationErrors;
using Projeto01.Application.Commands.Empresas;
using Projeto01.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto01.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaApplicationService _empresaApplicationService;

        public EmpresasController(IEmpresaApplicationService empresaApplicationService)
        {
            _empresaApplicationService = empresaApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmpresaCreateCommand command)
        {
            try
            {
                await _empresaApplicationService.Create(command);
                return StatusCode(201, new { Message = "Empresa cadastrada com sucesso." });
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
        public async Task<IActionResult> Put(EmpresaUpdateCommand command)
        {
            try
            {
                await _empresaApplicationService.Update(command);
                return Ok(new { Message = "Empresa atualizada com sucesso." });
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
                var command = new EmpresaDeleteCommand { Id = id };

                await _empresaApplicationService.Delete(command);
                return Ok(new { Message = "Empresa excluida com sucesso." });
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
                var result = _empresaApplicationService.GetAll();

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
                var result = _empresaApplicationService.GetById(id);

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
