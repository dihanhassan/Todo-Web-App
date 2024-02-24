using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface IGetAllTodosService
    {
        public Response GetAllTodos(int UserId);
      
    }
}
