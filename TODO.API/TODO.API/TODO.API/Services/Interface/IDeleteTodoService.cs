using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface IDeleteTodoService
    {
        public Response DeleteTodo(int id, int task_id);
    }
}
