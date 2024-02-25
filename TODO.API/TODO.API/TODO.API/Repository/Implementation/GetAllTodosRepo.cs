using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Models.Data;
using Dapper;

namespace TODO.API.Repository.Implementation
{
    public class GetAllTodosRepo :IGetAllTodosRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public GetAllTodosRepo(IConfiguration configuration,DapperDBContext dapperDBContext)
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext;
        }

        public List<Todo> GetAllTodos(int UserId)
        {
            
            List<Todo> TodoList = new List<Todo>();
            string query = "Select * From TodoTable_v2";
            using ( var connection = this._dapperDBContext.CreateConnection() )
            {

                TodoList = connection.Query<Todo>( query ).ToList();
               
            }

            return TodoList;
        }

    }
}
