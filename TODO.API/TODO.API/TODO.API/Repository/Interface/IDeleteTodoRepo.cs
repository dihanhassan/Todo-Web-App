using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Repository.Interface
{
    public interface IDeleteTodoRepo
    {
        public int  DeleteTodo(int id, int task_id);
    }
}
