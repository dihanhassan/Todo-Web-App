using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Models.Data;
using Dapper;

namespace TODO.API.Repository.Implementation
{
    public class LoginRepo : ILoginRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public LoginRepo(IConfiguration configuration, DapperDBContext dapperDBContext) 
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext; 
        }
        public Login UserValidition(Login login)
        {
           
            
            Login Credential = new Login();
            string query = "Select * from userAuth WHERE UserName = @UserName  AND UserPassword = @UserPassword";

            using (var connection = this._dapperDBContext.CreateConnection())
            {
                Credential = connection.QueryFirstOrDefault<Login>(query,login);

            }
            if(Credential == null)
            {
                Credential = new Login();
            }
            return Credential;
        }
    }
}
