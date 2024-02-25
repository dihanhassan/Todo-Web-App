using Dapper;
using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Models.Data;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class AddTodoRepo: IAddTodoRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public AddTodoRepo(IConfiguration configuration,DapperDBContext dapperDBContext)
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext;
        }
        public int  AddTodo(Todo todo)
        {
            

            string query = @"
            INSERT INTO TodoTable_v2 (Id, Title, Descriptions, CreatedOn, IsCompleted, DueDate, Prioritys) 
            VALUES (@Id, @Title, @Descriptions, GETDATE(), @IsCompleted, @DueDate, @Prioritys)
            ";
            int RowsCount = 0;
            
            using (var connection = this._dapperDBContext.CreateConnection())
            {

               RowsCount = connection.Execute(query, todo);

            }
            return RowsCount;


        }
    }
}
