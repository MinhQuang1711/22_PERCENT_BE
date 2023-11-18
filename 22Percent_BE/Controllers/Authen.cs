using _22Percent_BE.Data.DTOs.Authen;
using _22Percent_BE.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22Percent_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authen : ControllerBase
    {
        private readonly IServiceManagement _serviceManagement;

        public Authen(IServiceManagement serviceManagement) 
        {
            _serviceManagement=serviceManagement;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            try
            {
                var token= await _serviceManagement.AuthenticationService.Login(login);   
                if (token!=null)
                {
                    return Ok(token);   
                }
                return BadRequest(Message.LoginFaild);

            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}
