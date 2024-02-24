using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Repository.Interface
{
    public interface IUpdateTodoRepo
    {
        public int UpdateTodo(Todo todo);
        public int StatusUpdateTodo( Todo todo);
    }
}
