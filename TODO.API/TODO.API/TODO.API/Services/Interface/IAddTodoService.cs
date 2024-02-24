using TODO.API.Models;

namespace TODO.API.Services.Interface
{
    public interface IAddTodoService
    {
        public Response AddTodo(Todo todo);
    }
}
