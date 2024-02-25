using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class LoginRepo : ILoginRepo
    {
        private readonly IConfiguration _configuration;
        public LoginRepo(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public Login UserValidition(Login login)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM userAuth WHERE  UserName = '" + login.UserName + "' AND  UserPassword = '" + login.UserPassword + "' ", connection);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //Login Credential = new Login();
            //if(dt.Rows.Count > 0)
            //{
            //   Credential.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
            //   Credential.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
            //   Credential.UserPassword = Convert.ToString(dt.Rows[0]["UserPassword"]);

            //}
            Login Credential = new Login();
            string query = "Select * from userAuth WHERE UserName = @UserName  AND UserPassword = @UserPassword";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@UserName", login.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", login.UserPassword);

            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {

                    Credential.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                    Credential.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                     Credential.UserPassword = reader.GetString(reader.GetOrdinal("UserPassword"));
                }
            }

            return Credential;
        }
    }
}
