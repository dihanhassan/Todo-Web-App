using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class AddTodoRepo: IAddTodoRepo
    {
        private readonly IConfiguration _configuration;
        public AddTodoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int  AddTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            string query = @"INSERT INTO TodoTable_v2 (Id, Title, Descriptions, CreatedOn, IsCompleted, DueDate, Prioritys) 
                        VALUES (@Id, @Title, @Descriptions, GETDATE(), @IsCompleted, @DueDate, @Prioritys)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", todo.Id);
            //cmd.Parameters.AddWithValue("@Id", todo.Id);
            cmd.Parameters.AddWithValue("@Title", todo.Title);
            cmd.Parameters.AddWithValue("@Descriptions", todo.Descriptions);
            cmd.Parameters.AddWithValue("@IsCompleted", todo.IsCompleted);
            cmd.Parameters.AddWithValue("@DueDate", todo.DueDate);
            cmd.Parameters.AddWithValue("@Prioritys", todo.Prioritys);

            connection.Open();
            int RowsCount = cmd.ExecuteNonQuery();
            return RowsCount;
        }
    }
}
