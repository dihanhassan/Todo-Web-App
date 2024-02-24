using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface ITodoFilterService
    {
        public Response GetAllTodosUsingFilter( string FilterOption, int UserId);
        public Response GetAllTodosUsingStatus(int FilterOption, int id);
        public Response GetAllTodosUsingSearch(string SearchText, int id);
    }
}
