using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Repository.Interface
{
    public interface ITodoFilterRepo
    {
        public List<Todo> GetAllTodosUsingFilter(string FilterOption, int UserId);
        public List<Todo> GetAllTodosUsingStatus( int FilterOption, int id);
        public List<Todo> GetAllTodosUsingSearch(string SearchText, int id);
    }
}
