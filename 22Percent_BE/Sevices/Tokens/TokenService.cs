using _22Percent_BE.Data.DTOs;
using _22Percent_BE.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _22Percent_BE.Sevices.Tokens
{
    public class TokenService:ITokenService
    {
        string _secretKey;
        private readonly IConfiguration _configuration;
        private readonly SigningCredentials _signingCredentials;

        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
            _secretKey = configuration["SecretKey"];
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secretKey)), SecurityAlgorithms.HmacSha256);

        }

        public Token GenerateToken(User user)
        {
            return new Token 
            {
                AccessToken=GenerateAccessToken(user),
                RefreshToken=GenerateRefreshToken(user),
            };
        }

        private string GenerateAccessToken(User user)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Id)
            };

            var accessToken = new JwtSecurityToken
                (
                    _configuration["Issuer"],
                    _configuration["Audience"], 
                    claims,
                    expires: DateTime.UtcNow.AddDays(1), 
                    signingCredentials: _signingCredentials
                    
                ) ;
            return tokenHandle.WriteToken(accessToken) ;
        }

        private string GenerateRefreshToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("UserName", user.Id)
                    }),
                Expires = DateTime.UtcNow.AddDays(7), 
                SigningCredentials = _signingCredentials,
            };
            var refreshToken= tokenHandler.CreateToken(tokenDescriptor);   
    
            return tokenHandler.WriteToken(refreshToken);
        }
    }
}
