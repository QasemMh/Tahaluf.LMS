using Microsoft.AspNetCore.Mvc;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JwtController : Controller
    {
        private readonly IJwtService jwtService;
        public JwtController(IJwtService _jwtService)
        {
            jwtService = _jwtService;
        }


        [HttpPost]
        public IActionResult Authen([FromBody] Login login)
        {
            var token = jwtService.Auth(login);
            if (token == null)
                return Unauthorized();


            return Ok(token);
        }


    }
}
