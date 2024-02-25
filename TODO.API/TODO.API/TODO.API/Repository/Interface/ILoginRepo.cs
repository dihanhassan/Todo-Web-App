using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Repository.Interface
{
    public interface ILoginRepo
    {
        public asyc Task<Login> UserValidition(Login login)
    }
}
