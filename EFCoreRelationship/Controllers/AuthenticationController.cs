using EFCoreRelationship.Data;
using EFCoreRelationship.DTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFCoreRelationship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post([FromBody] UserLoginDto request)
        {
            if (!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
                var response = await _authRepository.Login(request.UserName, request.Password);
                if(!response.Success)
                {
                    return BadRequest(response);
                }    
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto request)
        {
            if(!string.IsNullOrEmpty(request.UserName) && !string.IsNullOrEmpty(request.Password))
            {
               var response = await _authRepository.Register(new Models.User {  UserName = request.UserName }, request.Password);

                if(!response.Success)
                {
                    return BadRequest(response);
                } 
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
