using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VehicleLoan.BusinessModels;
using VehicleLoan.DataAccessLayer.Repository.Abstraction;

namespace VehicleLoan.DataAccessLayer.Repository.Implementation
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private IConfiguration configuration;
        public JwtTokenManager(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public string GenerateJwt(UserRegistrationModel user)
        {
            string secretKey = this.configuration["Jwt:Key"];
            byte[] secrectKeyByteArray = Encoding.UTF8.GetBytes(secretKey);
            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(secrectKeyByteArray);
            SigningCredentials signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);

            Claim userNameBasedClaim = new Claim(ClaimTypes.Email, user.UserId);
              
            Claim[] userClaims = new Claim[] { userNameBasedClaim };
            ClaimsIdentity identiy = new ClaimsIdentity(userClaims);
            SecurityTokenDescriptor tokeDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this.configuration["Jwt:Issuer"],
                Audience = this.configuration["Jwt:Audience"],
                IssuedAt = DateTime.Now,
                Subject = identiy,
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = signingCredentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokeDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
