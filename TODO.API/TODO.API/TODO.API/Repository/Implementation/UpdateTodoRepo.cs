using Dapper;
using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Models.Data;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class UpdateTodoRepo : IUpdateTodoRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public UpdateTodoRepo (IConfiguration configuration,DapperDBContext dapperDBContext)
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext; 
        }
        public int UpdateTodo(Todo todo)
        {
            
            string query = "UPDATE TodoTable_v2 SET Title = @Title, Descriptions = @Descriptions, DueDate = @DueDate, Prioritys = @Prioritys, IsCompleted = @IsCompleted WHERE ID = @Id AND TaskID = @TaskId";
            int RowsCount = 0;  

            using (var connection = _dapperDBContext.CreateConnection())
            {
                RowsCount = connection.Execute(query, todo);
            }
            return RowsCount;
        }

        public int StatusUpdateTodo(Todo todo)
        {
           
            int RowsCount = 0;
            string query = "UPDATE TodoTable_v2 SET IsCompleted = @IsCompleted WHERE ID = @Id AND TaskId = @TaskId";
            using (var connection = _dapperDBContext.CreateConnection())
            {
                RowsCount = connection.Execute(query,todo);
            }


            return RowsCount;
        }


    }
}
