using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class UpdateTodoRepo : IUpdateTodoRepo
    {
        private readonly IConfiguration _configuration;

        public UpdateTodoRepo (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int UpdateTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            SqlCommand cmd = new SqlCommand("UPDATE  TodoTable_v2 SET Title =  '" + todo.Title + "', Descriptions = '" + todo.Descriptions + "', DueDate = '" + todo.DueDate + "', Prioritys = '" + todo.Prioritys + "', IsCompleted = '" + todo.IsCompleted + "'   WHERE ID = '" + todo.Id + "' AND TaskID = '" + todo.TaskId + "'  ", connection);
            connection.Open();
            int RowsCount = cmd.ExecuteNonQuery();
            connection.Close();
            return RowsCount;
        }

        public int StatusUpdateTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            SqlCommand cmd = new SqlCommand("UPDATE  TodoTable_v2 SET  IsCompleted = '" + todo.IsCompleted + "'   WHERE ID = '" + todo.Id + "' AND TaskId= '" + todo.TaskId + "' ", connection);
            connection.Open();
            int RowsCount = cmd.ExecuteNonQuery();
            connection.Close();
            return RowsCount;
        }


    }
}
