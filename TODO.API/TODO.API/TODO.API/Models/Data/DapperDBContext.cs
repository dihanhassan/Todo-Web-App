using System.Data;
using System.Data.SqlClient;

namespace TODO.API.Models.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring; 
        public DapperDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionstring = this._configuration.GetConnectionString("serverConnection");

        }
        public IDbConnection CreateConnection() => new SqlConnection (this._connectionstring);

    }
}
