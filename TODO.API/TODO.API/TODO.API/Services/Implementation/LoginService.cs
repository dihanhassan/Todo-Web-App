using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _loginRepo;
        public LoginService (ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }
        public AuthResponse UserValidition(Login login)
        {
            AuthResponse authResponse = new AuthResponse();

            Login Credential =  _loginRepo.UserValidition(login);
            if(Credential.UserName ==login.UserName && Credential.UserPassword!=login.UserPassword)
            {
                authResponse.StatusCode = 100;
                authResponse.StatusMessage = "login Failed";
                
            }
            else
            {
                authResponse.StatusCode = 200;
                authResponse.StatusMessage = "login Success!";
                authResponse.Login = Credential;
            }
            return authResponse;
        }
    }
}
