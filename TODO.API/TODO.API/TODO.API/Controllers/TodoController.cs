using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TODO.API.Models;
using TODO.API.Services.Interface;

namespace TODO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IGetAllTodosService _getAllTodosService;
        private readonly IAddTodoService _addTodoService;
        private readonly IUpdateTodoService _updateTodoService;
        private readonly IDeleteTodoService _deleteTodoService;
        private readonly ITodoFilterService _filterService;
        public TodoController(
            IGetAllTodosService getAllTodosService, 
            IAddTodoService addTodoService,IUpdateTodoService updateTodoService,
            IDeleteTodoService deleteTodoService,
            ITodoFilterService filterService
        )
        {
            _getAllTodosService = getAllTodosService;
            _addTodoService = addTodoService;   
            _updateTodoService = updateTodoService;
            _deleteTodoService = deleteTodoService;
            _filterService = filterService;
        }

        [HttpGet]
        [Route("GetAllTodos/{id}")]
        
        public Response GetAllTodos(int id)
        {
           
            return _getAllTodosService.GetAllTodos(id);
           
        }
        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodo(Todo todo)
        {
          
            return _addTodoService.AddTodo(todo);
        }

        [HttpPut]
        [Route("UpdateTodo")]
        public Response UpdateTodo(Todo todo)
        {
           return _updateTodoService.UpdateTodo(todo);
        }
        [HttpDelete]
        [Route("DeleteTodo/{id}/{task_id}")]
        public Response DeleteTodo(int id,int task_id)
        {
            return _deleteTodoService.DeleteTodo(id,task_id);
        }

        [HttpGet]
        [Route("GetAllTodosUsingFilter/{FilterOption}/{UserId}")]

        public Response GetAllTodosUsingFilter(string FilterOption, int UserId)
        {
            return _filterService.GetAllTodosUsingFilter(FilterOption, UserId);
        }
        [HttpGet]
        [Route("GetAllTodosUsingStatus/{FilterOption}/{id}")]

        public Response GetAllTodosUsingStatus(int FilterOption, int id)
        {
            return _filterService.GetAllTodosUsingStatus(FilterOption, id);

        }

        [HttpGet]
        [Route("GetAllTodosUsingSearch/{SearchText}/{id}")]

        public Response GetAllTodosUsingSearch(string SearchText, int id)
        {
           
            return _filterService.GetAllTodosUsingSearch(SearchText, id);
        }
        [HttpPatch]
        [Route("StatusUpdateTodo")]
        public Response StatusUpdateTodo(Todo todo)
        {
           return _updateTodoService.StatusUpdateTodo(todo);
        }

    }   
}
