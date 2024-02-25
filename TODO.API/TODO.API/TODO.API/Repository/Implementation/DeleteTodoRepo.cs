using Dapper;
using System.Data.SqlClient;
using TODO.API.Models.Data;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class DeleteTodoRepo :IDeleteTodoRepo
    {
        private readonly IConfiguration _configuration;
        private readonly DapperDBContext _dapperDBContext;
        public DeleteTodoRepo(IConfiguration configuration,DapperDBContext  dapperDBContext)
        {
            _configuration = configuration;
            _dapperDBContext = dapperDBContext;
        }
        public int DeleteTodo(int id, int task_id)
        {
            
            int RowsCount = 0;
            string querry = "Delete from TodoTable_v2 WHERE ID = @Id AND TaskID = @TaskId";
            using (var connection = _dapperDBContext.CreateConnection())
            {
                RowsCount = connection.Execute(querry, new { Id = id, TaskId = task_id });

            }
            return RowsCount;

        }
    }
}
