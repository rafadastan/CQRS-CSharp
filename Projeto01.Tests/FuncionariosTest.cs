using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Newtonsoft.Json;
using Projeto01.Application.Commands.Funcionarios;
using Projeto01.Domain.Models;
using Projeto01.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projeto01.Tests
{
    public class FuncionariosTest
    {
        private readonly Faker _faker;

        public FuncionariosTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task Funcionarios_Post_Returns_Created()
        {
            //executar a consulta de empresas
            var empresas = await new EmpresasTest().Empresas_GetAll_Returns_Ok();
            var empresa = empresas.FirstOrDefault();

            var client = HttpClientHelper.Create();

            var command = new FuncionarioCreateCommand
            {
                Nome = _faker.Person.FullName,
                Cpf = _faker.Person.Cpf()
                        .Replace(".", string.Empty)
                        .Replace("-", string.Empty),
                DataAdmissao = _faker.Date.Recent(10),
                Matricula = (Convert.ToInt32(_faker.Finance.Amount(100000, 999999))).ToString(),
                EmpresaId = empresa.Id
            };

            var request = RequestHelper.Create(command);

            await AuthenticationHelper.Create(client);

            var response = await client.PostAsync("api/funcionarios", request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Funcionarios_Put_Returns_Ok()
        {
            var funcionarios = await Funcionarios_GetAll_Returns_Ok();
            var funcionario = funcionarios.LastOrDefault();

            var client = HttpClientHelper.Create();

            var command = new FuncionarioUpdateCommand
            {
                Id = funcionario.Id,
                Nome = _faker.Person.FullName,
                Cpf = funcionario.Cpf,
                Matricula = funcionario.Matricula,
                DataAdmissao = _faker.Date.Recent(10),
                EmpresaId = funcionario.EmpresaId
            };

            var request = RequestHelper.Create(command);

            await AuthenticationHelper.Create(client);

            var response = await client.PutAsync("api/funcionarios", request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Funcionarios_Delete_Returns_Ok()
        {
            var funcionarios = await Funcionarios_GetAll_Returns_Ok();
            var funcionario = funcionarios.LastOrDefault();

            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.DeleteAsync($"api/funcionarios/{funcionario.Id}");

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task<List<FuncionarioModel>> Funcionarios_GetAll_Returns_Ok()
        {
            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.GetAsync("api/funcionarios");

            var result = JsonConvert.DeserializeObject<List<FuncionarioModel>>
                (response.Content.ReadAsStringAsync().Result);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            result
                .Should()
                .NotBeNullOrEmpty();

            return result;
        }

        [Fact]
        public async Task Funcionarios_GetById_Returns_Ok()
        {
            //executar a consulta de funcionarios
            var funcionarios = await Funcionarios_GetAll_Returns_Ok();
            var funcionario = funcionarios.FirstOrDefault();

            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.GetAsync($"api/funcionarios/{funcionario.Id}");

            var result = JsonConvert.DeserializeObject<FuncionarioModel>
                (response.Content.ReadAsStringAsync().Result);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            result.Nome.Should().Be(funcionario.Nome);
            result.Cpf.Should().Be(funcionario.Cpf);
            result.Matricula.Should().Be(funcionario.Matricula);
        }
    }
}
