using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWebApp.Shared.Helpers
{
    public class GenerateToken
    {

        /// <summary>
        /// ////////////////////
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>

        public string GenerateJSONWebToken(string userId, string emailAddress)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, "JWTServiceAccessToken"),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userId),

                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                "http://localhost:5273/",
                "http://localhost:5273/",
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      
    }
}
