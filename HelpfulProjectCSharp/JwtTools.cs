using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HelpfulProjectCSharp
{
    public static class JwtTools
    {
        public static string GenerateJwtToken(ClaimsIdentity identity,string key,string issuer,string audience)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            DateTime ExpiresDateTime = DateTime.Today;
            ExpiresDateTime = ExpiresDateTime.AddHours(23);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = ExpiresDateTime,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
