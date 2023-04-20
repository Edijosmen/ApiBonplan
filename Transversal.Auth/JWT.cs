using Aplication.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Auth
{
    public  class  JWT
    {
        public static string GetToken(UserDto user ,IConfiguration config)
        {
            string Issuer = config.GetSection("Jwt:Issuer").Value;
            string Audience = config.GetSection("Jwt:Audience").Value;
            //param para token
            SymmetricSecurityKey securityKey = new(Encoding.ASCII.GetBytes(config.GetSection("Jwt:Key").Value));
            SigningCredentials credentials = new (securityKey,SecurityAlgorithms.HmacSha512);

            // crear claims
            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, user.Usuario)
            };
            //config token
            JwtSecurityToken jwtToken = new (
                    Issuer,
                    Audience,
                    claims, 
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }
    }
}
