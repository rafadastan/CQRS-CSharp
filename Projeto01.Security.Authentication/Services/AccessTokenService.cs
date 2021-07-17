using Microsoft.IdentityModel.Tokens;
using Projeto01.Security.Authentication.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Security.Authentication.Services
{
    public class AccessTokenService
    {
        private readonly AccessTokenSettings _acessTokenSettings;

        public AccessTokenService(AccessTokenSettings acessTokenSettings)
        {
            _acessTokenSettings = acessTokenSettings;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_acessTokenSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(_acessTokenSettings.ExpirationInHours),

                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
