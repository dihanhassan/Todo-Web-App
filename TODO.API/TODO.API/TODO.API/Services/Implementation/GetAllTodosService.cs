using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class GetAllTodosService : IGetAllTodosService
    {
        private readonly IGetAllTodosRepo _repo;
        public GetAllTodosService(IGetAllTodosRepo repo)
        {
            _repo = repo;
        }
        public Response GetAllTodos(int UserId)
        {
            Response response = new Response();

            List<Todo> TodoList = _repo.GetAllTodos(UserId);

            if(TodoList.Count > 0)
            {
                List<Todo> CompleteTodoList = new List<Todo>();
                List<Todo> FinalTodoList = new List<Todo>();
                foreach (Todo todo in TodoList)
                {
                    if (todo.Id != UserId)
                    {
                        continue;
                    }
                    if (todo.IsCompleted == 1) 
                    {
                        CompleteTodoList.Add(todo);
                    }
                    else
                    {
                        FinalTodoList.Add(todo);
                    }
                   
                }
                FinalTodoList = FinalTodoList.Concat(CompleteTodoList).ToList();

                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.ListTodos = FinalTodoList;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.ListTodos = null;
            }
            


            return response;
        }
    }
}
