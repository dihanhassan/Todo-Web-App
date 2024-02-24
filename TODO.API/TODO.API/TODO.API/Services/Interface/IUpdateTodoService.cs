using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface IUpdateTodoService
    {
        public Response UpdateTodo(Todo todo);
        public Response StatusUpdateTodo(Todo todo);
        
    }
}
