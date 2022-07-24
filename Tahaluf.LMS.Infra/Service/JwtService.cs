using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.Repository;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.Infra.Service
{
     public class JwtService : IJwtService
    {
        private readonly IJwtRepository jwtRepository;
        public JwtService(IJwtRepository _jwtRepository)
        {
            jwtRepository = _jwtRepository;
        }

        public string Auth(Login login)
        {
            var result = jwtRepository.Auth(login);
            if (result == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@515"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, result.Username),
                    new Claim(ClaimTypes.Role, result.RoleId.ToString())
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(tokenKey,
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
