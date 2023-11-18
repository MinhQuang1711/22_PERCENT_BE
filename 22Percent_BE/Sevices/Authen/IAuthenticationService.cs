using _22Percent_BE.Data.DTOs;
using _22Percent_BE.Data.DTOs.Authen;

namespace _22Percent_BE.Sevices.Authen
{
    public interface  IAuthenticationService
    {
        public Task<Token?> Login(LoginDto login);
    }
}
