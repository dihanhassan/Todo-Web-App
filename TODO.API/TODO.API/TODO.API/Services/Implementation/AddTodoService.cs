using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class AddTodoService : IAddTodoService
    {
        private readonly IAddTodoRepo _repo;
        public AddTodoService( IAddTodoRepo repo)
        { 
           _repo = repo;
            
        }

        public Response AddTodo(Todo todo)
        {


            Response response = new Response();

            int RowsCount = _repo.AddTodo(todo);

            if (RowsCount > 0 )
            {
                response.StatusCode = 200;
                response.StatusMessage = "Todo Added";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data inserted";
            }

            return response;
        }
    }
}
