using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Repository.Interface;
using TODO.API.Services.Interface;

namespace TODO.API.Services.Implementation
{
    public class TodoFilterService : ITodoFilterService
    {
        private readonly ITodoFilterRepo _repo;
        public TodoFilterService(ITodoFilterRepo repo) 
        { 
            _repo = repo;
        
        }
        public Response GetAllTodosUsingFilter(string FilterOption, int UserId)
        {
            Response response = new Response();

            List<Todo> CompleteTodoList = new List<Todo>();
            List<Todo> FinalTodoList = new List<Todo>();


            List<Todo> TodoList = _repo.GetAllTodosUsingFilter(FilterOption, UserId);
            
           if(TodoList.Count > 0)
            {
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

        public Response GetAllTodosUsingStatus(int FilterOption, int id)
        {
            Response response = new Response();

            List<Todo> CompleteTodoList = new List<Todo>();
            List<Todo> FinalTodoList = new List<Todo>();


            List<Todo> TodoList = _repo.GetAllTodosUsingStatus(FilterOption, id);

            if (TodoList.Count > 0)
            {
                foreach (Todo todo in TodoList)
                {
                    if (todo.Id != id)
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
                response.StatusCode = 200;
                response.StatusMessage = "Data found";

                if (FilterOption == 1)
                {
                    response.ListTodos = CompleteTodoList;
                }
                else
                {
                    response.ListTodos = FinalTodoList;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.ListTodos = null;
            }
            return response;
        }
        public Response GetAllTodosUsingSearch(string SearchText, int id)
        {
            Response response = new Response();

            List<Todo> CompleteTodoList = new List<Todo>();
            List<Todo> FinalTodoList = new List<Todo>();


            List<Todo> TodoList = _repo.GetAllTodosUsingSearch(SearchText, id);

            if (TodoList.Count > 0)
            {
                foreach (Todo todo in TodoList)
                {
                    if (todo.Id != id)
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
