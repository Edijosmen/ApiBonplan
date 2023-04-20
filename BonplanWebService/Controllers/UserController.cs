using Aplication.Dto;
using Aplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonplanWebService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthAplication _appService;
        public UserController(IAuthAplication appService)
        {
            _appService = appService;
        }
        [Route("Auth/login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var response = await _appService.ValidateCredentials(userDto);
            if (response.IsSuccess)
            {
                var token = await _appService.GenerarToken(userDto);
                return Ok(token.Data);
            }
            return BadRequest(response);

        }
        [Route("Auth/registro")]
        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var response = await _appService.SaveUser(userDto);
            if (response.IsSuccess ==true) return Ok(response);
            return BadRequest(response);

        }
    }
}
