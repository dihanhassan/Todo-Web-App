using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface ILoginService
    {
        public AuthResponse UserValidition(Login login);
    }
}
