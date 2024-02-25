using System.Data.SqlClient;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class DeleteTodoRepo :IDeleteTodoRepo
    {
        private readonly IConfiguration _configuration;
        public DeleteTodoRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int DeleteTodo(int id, int task_id)
        {
            //SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            //SqlCommand cmd = new SqlCommand("Delete from TodoTable_v2 WHERE ID = '" + id + "' AND TaskId = '" + task_id + "'", connection);
            //connection.Open();
            //int RowsCount = cmd.ExecuteNonQuery();
            //connection.Close();
            //return RowsCount;
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            string querry = "Delete from TodoTable_v2 WHERE ID = @Id AND TaskID = @TaskId";
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@TaskId", task_id);

            connection.Open();
            return cmd.ExecuteNonQuery();

        }
    }
}
