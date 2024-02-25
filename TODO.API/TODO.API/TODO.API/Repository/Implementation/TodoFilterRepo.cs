using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Models.Data;
using Dapper;

namespace TODO.API.Repository.Implementation
{
    public class TodoFilterRepo : ITodoFilterRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public TodoFilterRepo(IConfiguration configuration, DapperDBContext dapperDBContext)
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext; 
        }
        public List<Todo> GetAllTodosUsingFilter(string FilterOption, int UserId)
        {

            List<Todo> todoList = new List<Todo>();

   
            string query = $"SELECT * FROM TodoTable_v2 ORDER BY {FilterOption}";

            using (var connection = _dapperDBContext.CreateConnection())
            {
               
                todoList = connection.Query<Todo>(query).ToList();
            }

            return todoList;



        }

        public List<Todo> GetAllTodosUsingStatus(int FilterOption, int id)
        {
            List<Todo> TodoList = new List<Todo>();

          
            string query = "SELECT * FROM TodoTable_v2 WHERE Id = @Id";
            using (var connection = _dapperDBContext.CreateConnection())
            {
                TodoList = connection.Query<Todo>(query, new { Id = id }).ToList();
            }


            return TodoList;

        }

        public List<Todo> GetAllTodosUsingSearch(string SearchText, int id)
        {
            List<Todo> TodoList = new List<Todo>();

          
            string query = "SELECT * FROM TodoTable_v2 WHERE (Title LIKE @SearchTextStart OR Title LIKE @SearchTextMiddle OR Title LIKE @SearchTextEnd) AND Id = @Id";

            using (var connection = _dapperDBContext.CreateConnection())
            {
               
                TodoList = connection.Query<Todo>(query,
                    new {
                        SearchTextStart = $"{SearchText}%",
                        SearchTextMiddle = $"%{SearchText}%",
                        SearchTextEnd = $"%{SearchText}",
                        Id = id 
                    }).ToList();
            }




            return TodoList;
        }

    }
}
