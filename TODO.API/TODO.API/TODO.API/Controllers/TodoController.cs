using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TODO.API.Models;

namespace TODO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllTodos/{id}")]
        
        public Response GetAllTodos(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodos(connection,id);
            return response;
        }
        [HttpPost]
        [Route("AddTodo")]
        public Response AddTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddTodo(connection, todo);
            return response;
        }

        [HttpPut]
        [Route("UpdateTodo")]
        public Response UpdateTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateTodo(connection, todo);
            return response;
        }

        [HttpDelete]
        [Route("DeleteTodo/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteTodo(connection, id);
            return response;
        }


        [HttpGet]
        [Route("GetAllTodosUsingFilter/{FilterOption}/{userId}")]

        public Response GetAllTodosUsingFilter(string FilterOption,int UserId)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodosUsingFilter(connection,FilterOption, UserId);
            return response;
        }
        [HttpPatch]
        [Route("StatusUpdateTodo")]
        public Response StatusUpdateTodo(Todo todo)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.StatusUpdateTodo(connection, todo);
            return response;
        }

        [HttpGet]
        [Route("GetAllTodosUsingSearch/{SearchText}")]

        public Response GetAllTodosUsingSearch(string SearchText)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodosUsingSearch(connection, SearchText);
            return response;
        }

        [HttpPost]
        [Route("UserValidition")]
        public AuthResponse UserValidition(Login login)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            AuthResponse response = new AuthResponse();
            DAL dal = new DAL();
            response = dal.UserValidition(connection, login);
            return response;
        }

        [HttpGet]
        [Route("GetAllTodosUsingStatus/{FilterOption}")]

        public Response GetAllTodosUsingStatus(int  FilterOption)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllTodosUsingStatus(connection, FilterOption);
            return response;
        }


    }   
}
