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
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString()))
            {
                string query = "UPDATE TodoTable_v2 SET Title = @Title, Descriptions = @Descriptions, DueDate = @DueDate, Prioritys = @Prioritys, IsCompleted = @IsCompleted WHERE ID = @Id AND TaskID = @TaskId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Title", todo.Title);
                cmd.Parameters.AddWithValue("@Descriptions", todo.Descriptions);
                cmd.Parameters.AddWithValue("@DueDate", todo.DueDate);
                cmd.Parameters.AddWithValue("@Prioritys", todo.Prioritys);
                cmd.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@TaskId", todo.TaskId);

                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public int StatusUpdateTodo(Todo todo)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString()))
            {
                string query = "UPDATE TodoTable_v2 SET IsCompleted = @IsCompleted WHERE ID = @Id AND TaskId = @TaskId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
                cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@TaskId", todo.TaskId);

                connection.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }


    }
}
