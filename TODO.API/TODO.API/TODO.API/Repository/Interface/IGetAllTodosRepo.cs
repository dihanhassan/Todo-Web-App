using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Repository.Interface
{
    public interface IGetAllTodosRepo
    {
        public List<Todo> GetAllTodos( int UserId);
    }
}
