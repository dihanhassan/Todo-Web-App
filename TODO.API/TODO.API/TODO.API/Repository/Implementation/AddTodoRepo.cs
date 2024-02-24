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
            SqlCommand cmd = new SqlCommand("INSERT INTO TodoTable_v2 (Id , Title , Descriptions ,CreatedOn ,IsCompleted ,DueDate, Prioritys) VALUES ( '" + todo.Id + "' ,'" + todo.Title + "', '" + todo.Descriptions + "', GETDATE() ,'" + todo.IsCompleted + "' , '" + todo.DueDate + "' , '" + todo.Prioritys + "' )", connection);
            connection.Open();
            int RowsCount = cmd.ExecuteNonQuery();
            connection.Close();
            return RowsCount;
        }
    }
}
