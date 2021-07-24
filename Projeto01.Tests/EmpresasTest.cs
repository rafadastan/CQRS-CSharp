using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using Newtonsoft.Json;
using Projeto01.Application.Commands.Empresas;
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
    public class EmpresasTest
    {
        private readonly Faker _faker;

        public EmpresasTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task Empresas_Post_Returns_Created()
        {
            var client = HttpClientHelper.Create();

            var command = new EmpresaCreateCommand
            {
                NomeFantasia = _faker.Company.CompanyName(),
                RazaoSocial = _faker.Company.CompanyName(),
                Cnpj = _faker.Company.Cnpj()
                        .Replace(".", string.Empty)
                        .Replace("/", string.Empty)
                        .Replace("-", string.Empty)
            };

            var request = RequestHelper.Create(command);

            await AuthenticationHelper.Create(client);

            var response = await client.PostAsync("api/empresas", request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task Empresas_Put_Returns_Ok()
        {
            //executar a consulta de empresas
            var empresas = await Empresas_GetAll_Returns_Ok();
            //ler a primeira empresa obtida
            var empresa = empresas.LastOrDefault();

            var client = HttpClientHelper.Create();

            var command = new EmpresaUpdateCommand
            {
                Id = empresa.Id,
                NomeFantasia = _faker.Company.CompanyName(),
                RazaoSocial = _faker.Company.CompanyName(),
                Cnpj = empresa.Cnpj
            };

            var request = RequestHelper.Create(command);

            await AuthenticationHelper.Create(client);

            var response = await client.PutAsync("api/empresas", request);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Empresas_Delete_Returns_Ok()
        {
            //executar a consulta de empresas
            var empresas = await Empresas_GetAll_Returns_Ok();
            //ler a primeira empresa obtida
            var empresa = empresas.LastOrDefault();

            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.DeleteAsync($"api/empresas/{empresa.Id}");

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task<List<EmpresaModel>> Empresas_GetAll_Returns_Ok()
        {
            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.GetAsync("api/empresas");

            var result = JsonConvert.DeserializeObject<List<EmpresaModel>>
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
        public async Task Empresas_GetById_Returns_Ok()
        {
            //executar a consulta de empresas
            var empresas = await Empresas_GetAll_Returns_Ok();
            //ler a primeira empresa obtida
            var empresa = empresas.FirstOrDefault();

            var client = HttpClientHelper.Create();

            await AuthenticationHelper.Create(client);

            var response = await client.GetAsync($"api/empresas/{empresa.Id}");

            var result = JsonConvert.DeserializeObject<EmpresaModel>
                (response.Content.ReadAsStringAsync().Result);

            response.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            result.NomeFantasia.Should().Be(empresa.NomeFantasia);
            result.RazaoSocial.Should().Be(empresa.RazaoSocial);
            result.Cnpj.Should().Be(empresa.Cnpj);
        }
    }
}
