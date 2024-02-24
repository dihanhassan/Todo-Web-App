using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class GetAllTodosRepo :IGetAllTodosRepo
    {
        private readonly IConfiguration _configuration;
        public GetAllTodosRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Todo> GetAllTodos(int UserId)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TodoTable_v2 ORDER BY ID DESC", connection);
            DataTable dt = new DataTable();
            List<Todo> TodoList = new List<Todo>();
            da.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; ++i)
            {
                Todo todo = new Todo();
                todo.TaskId = Convert.ToInt32(dt.Rows[i]["TaskId"]);
                todo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                todo.Title = Convert.ToString(dt.Rows[i]["Title"]);
                todo.Descriptions = Convert.ToString(dt.Rows[i]["Descriptions"]);
                todo.IsCompleted = Convert.ToInt32(dt.Rows[i]["IsCompleted"]);
                todo.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                todo.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"]);
                todo.Prioritys = Convert.ToString(dt.Rows[i]["Prioritys"]);
                TodoList.Add(todo);
            }

            return TodoList;
        }

    }
}
