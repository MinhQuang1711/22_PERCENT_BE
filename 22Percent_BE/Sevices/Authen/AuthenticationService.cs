using _22Percent_BE.Data.DTOs;
using _22Percent_BE.Data.DTOs.Authen;
using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Tokens;

namespace _22Percent_BE.Sevices.Authen
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly IRepositoryManagement _repositoryManagement;

        public AuthenticationService(IRepositoryManagement repositoryManagement, ITokenService tokenService) 
        {
            _tokenService= tokenService;    
            _repositoryManagement=repositoryManagement; 
        }  

        public async Task<Token?> Login(LoginDto login)
        {
            var user= await _repositoryManagement.UserRepository.GetUserByUserNameAndPassword(login.UserName, login.Password);
            if (user != null)
            {
                return _tokenService.GenerateToken(user);
            }
            return null;       
        }
    }
}
