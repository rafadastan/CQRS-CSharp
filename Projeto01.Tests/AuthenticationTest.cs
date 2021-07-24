using FluentAssertions;
using Newtonsoft.Json;
using Projeto01.Application.Commands.Usuarios;
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
    public class AuthenticationTest
    {
        [Fact]
        public async Task<string> Authentication_Post_Returns_Ok()
        {
            //conectar na API..
            var client = HttpClientHelper.Create();

            //criando o objeto da requisição
            var command = new AuthenticationCommand
            {
                Email = "admin@gmail.com",
                Senha = "adminadmin"
            };

            //'empacotando' o objeto para JSON
            var request = RequestHelper.Create(command);

            //fazendo a requisição de autenticação 'POST'
            var response = await client.PostAsync("api/auth", request);

            //capturar o retorno obtido da API
            var result = JsonConvert.DeserializeObject<AuthenticationResult>
                (response.Content.ReadAsStringAsync().Result);

            //criando um criterio de teste (assert)
            response.StatusCode
                .Should() //Fluent Assertions!
                .Be(HttpStatusCode.OK);

            //verificando a mensagem obtida
            result.Mensagem
                .Should() //Fluent Assertions!
                .Be("Usuário autenticado com sucesso");

            //verificando se o token foi obtido
            result.AccessToken
                .Should() //Fluent Assertions!
                .NotBeNullOrEmpty();

            //retornando o TOKEN..
            return result.AccessToken;
        }

        [Fact]
        public async Task Authentication_Post_Returns_Unauthorized()
        {
            //conectar na API..
            var client = HttpClientHelper.Create();

            //criando o objeto da requisição
            var command = new AuthenticationCommand
            {
                Email = "teste@gmail.com",
                Senha = "teste123456"
            };

            //'empacotando' o objeto para JSON
            var request = RequestHelper.Create(command);

            //fazendo a requisição de autenticação 'POST'
            var response = await client.PostAsync("api/auth", request);

            //criando um criterio de teste (assert)
            response.StatusCode
                .Should() //Fluent Assertions!
                .Be(HttpStatusCode.Unauthorized);
        }
    }

    class AuthenticationResult
    {
        public string Mensagem { get; set; }
        public string AccessToken { get; set; }
    }
}
