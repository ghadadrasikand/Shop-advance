using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Host.Security
{
    public static class TokenValidator
    {
        public static ClaimsPrincipal Validate(string token)
        {
            JwtSecurityTokenHandler Handler = new JwtSecurityTokenHandler();
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bahram ke goor migerefti hame omr$%^UU8(@#"))
            };

            ClaimsPrincipal principal = Handler.ValidateToken(token, parameters, out SecurityToken securityToken);
            return principal;
        }
        //public static IEnumerable<> GetClaims(ClaimsPrincipal principal)
        //{
        //    principal.Claims.ToList();
        //}
        }
}
