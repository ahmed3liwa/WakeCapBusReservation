using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WakecapBusReservation.Domain.Interfaces;
using WakecapBusReservation.Domain.Models.Idenitiy;

namespace WakecapBusReservation.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _Key;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }

        public string CreateToken(AppUser appUser)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };
            var cred = new SigningCredentials(_Key, SecurityAlgorithms.HmacSha512Signature);
            var TokenDesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = appUser.UserName,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,
                Issuer = _configuration["Token:Issuer"],

            };
            var tokenhandler = new JwtSecurityTokenHandler();
            var token = tokenhandler.CreateToken(TokenDesc);
            return tokenhandler.WriteToken(token);
        }
    }
}
