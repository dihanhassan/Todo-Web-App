using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class DeleteTodoService : IDeleteTodoService
    {
        private readonly IDeleteTodoRepo _deleteTodoRepo;

        public DeleteTodoService (IDeleteTodoRepo deleteTodoRepo)
        {
            _deleteTodoRepo = deleteTodoRepo;
        }

        public Response DeleteTodo(int id, int task_id)
        {
            Response response = new Response();
            int RowsCount = _deleteTodoRepo.DeleteTodo(id, task_id);
            if (RowsCount > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Deleted";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Deleted";
            }
            return response;

        }
    }
}
