using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Services.Interface;

namespace TODO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("UserValidition")]
        public AuthResponse UserValidition(Login login)
        {
              return _loginService.UserValidition(login);
         
        }
    }
}
