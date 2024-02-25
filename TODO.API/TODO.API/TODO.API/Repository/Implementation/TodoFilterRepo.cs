using System.Data.SqlClient;
using System.Data;
using TODO.API.Models;
using TODO.API.Repository.Interface;

namespace TODO.API.Repository.Implementation
{
    public class TodoFilterRepo : ITodoFilterRepo
    {
        private readonly IConfiguration _configuration;

        public TodoFilterRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Todo> GetAllTodosUsingFilter(string FilterOption, int UserId)
        {
           
            List<Todo> TodoList = new List<Todo>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString()))
            {
                string query = "SELECT * FROM TodoTable_v2 ORDER BY " + FilterOption;
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Todo todo = new Todo();
                        todo.TaskId = reader.GetInt32(reader.GetOrdinal("TaskId"));
                        todo.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        todo.Title = reader.GetString(reader.GetOrdinal("Title"));
                        todo.Descriptions = reader.GetString(reader.GetOrdinal("Descriptions"));
                        todo.IsCompleted = reader.GetInt32(reader.GetOrdinal("IsCompleted"));
                        todo.CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                        todo.DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
                        todo.Prioritys = reader.GetString(reader.GetOrdinal("Prioritys"));
                        TodoList.Add(todo);
                    }
                }
            }

            return TodoList;
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TodoTable_v2 ORDER BY '" + FilterOption + "'", connection);
            //DataTable dt = new DataTable();

            //da.Fill(dt);

            //for (int i = 0; i < dt.Rows.Count; ++i)
            //{
            //    Todo todo = new Todo();
            //    todo.TaskId = Convert.ToInt32(dt.Rows[i]["TaskId"]);
            //    todo.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
            //    todo.Title = Convert.ToString(dt.Rows[i]["Title"]);
            //    todo.Descriptions = Convert.ToString(dt.Rows[i]["Descriptions"]);
            //    todo.IsCompleted = Convert.ToInt32(dt.Rows[i]["IsCompleted"]);
            //    todo.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
            //    todo.DueDate = Convert.ToDateTime(dt.Rows[i]["DueDate"]);
            //    todo.Prioritys = Convert.ToString(dt.Rows[i]["Prioritys"]);
            //    TodoList.Add(todo);
            //}

            
        }

        public List<Todo> GetAllTodosUsingStatus(int FilterOption, int id)
        {
            List<Todo> TodoList = new List<Todo>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString()))
            {
                string query = "SELECT * FROM TodoTable_v2 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Todo todo = new Todo();
                            todo.TaskId = reader.GetInt32(reader.GetOrdinal("TaskId"));
                            todo.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            todo.Title = reader.GetString(reader.GetOrdinal("Title"));
                            todo.Descriptions = reader.GetString(reader.GetOrdinal("Descriptions"));
                            todo.IsCompleted = reader.GetInt32(reader.GetOrdinal("IsCompleted"));
                            todo.CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                            todo.DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
                            todo.Prioritys = reader.GetString(reader.GetOrdinal("Prioritys"));
                            TodoList.Add(todo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception or log error
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return TodoList;

        }

        public List<Todo> GetAllTodosUsingSearch(string SearchText, int id)
        {
            List<Todo> TodoList = new List<Todo>();

            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("serverConnection").ToString()))
            {
                string query = "SELECT * FROM TodoTable_v2 WHERE (Title LIKE @SearchTextStart OR Title LIKE @SearchTextMiddle OR Title LIKE @SearchTextEnd) AND Id = @Id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SearchTextStart", SearchText + "%");
                cmd.Parameters.AddWithValue("@SearchTextMiddle", "%" + SearchText + "%");
                cmd.Parameters.AddWithValue("@SearchTextEnd", "%" + SearchText);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Todo todo = new Todo();
                            todo.TaskId = reader.GetInt32(reader.GetOrdinal("TaskId"));
                            todo.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            todo.Title = reader.GetString(reader.GetOrdinal("Title"));
                            todo.Descriptions = reader.GetString(reader.GetOrdinal("Descriptions"));
                            todo.IsCompleted = reader.GetInt32(reader.GetOrdinal("IsCompleted"));
                            todo.CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                            todo.DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
                            todo.Prioritys = reader.GetString(reader.GetOrdinal("Prioritys"));
                            TodoList.Add(todo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception or log error
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return TodoList;
        }

    }
}
