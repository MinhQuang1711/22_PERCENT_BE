using _22Percent_BE.Data.DTOs;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Sevices.Tokens
{
    public interface ITokenService
    {
        public Token GenerateToken(User user);
    }
}
