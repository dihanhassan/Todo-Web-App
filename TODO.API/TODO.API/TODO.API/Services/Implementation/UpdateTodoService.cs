using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class UpdateTodoService :IUpdateTodoService
    {
        private readonly IUpdateTodoRepo _todoRepo;
        public UpdateTodoService(IUpdateTodoRepo todoRepo) 
        {
            _todoRepo = todoRepo;
            
        }

        public Response UpdateTodo(Todo todo)
        {
            Response response = new Response();

            int RowsCount = _todoRepo.UpdateTodo(todo);

            if (RowsCount > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Updated";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Updated";
            }

            return response;
        }

        public Response StatusUpdateTodo(Todo todo)
        {
            Response response = new Response();

            int RowsCount = _todoRepo.StatusUpdateTodo(todo);

            if (RowsCount > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Status Updated";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No  Updated";
            }

            return response;
        }
    }
}
