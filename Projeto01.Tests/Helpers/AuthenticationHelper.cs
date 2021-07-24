using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Tests.Helpers
{
    public class AuthenticationHelper
    {
        //método para executar o teste de autenticação na API
        //obter o TOKEN e adiciona-lo no HEADER da requisição
        public static async Task Create(HttpClient client)
        {
            //obtendo o token a partir do teste de autenticação
            var accessToken = await new AuthenticationTest()
                .Authentication_Post_Returns_Ok();

            //adicionar o TOKEN no cabeçalho da requisição
            //que será feita para a API
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
