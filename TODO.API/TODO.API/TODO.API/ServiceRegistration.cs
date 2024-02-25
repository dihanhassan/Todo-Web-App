using TODO.API.Repository.Implementation;
using TODO.API.Repository.Interface;
using TODO.API.Services.Implementation;
using TODO.API.Services.Interface;

namespace TODO.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddTransient<IGetAllTodosRepo, GetAllTodosRepo>();
            Services.AddTransient<IAddTodoRepo, AddTodoRepo>();
            Services.AddTransient<IUpdateTodoRepo, UpdateTodoRepo>();
            Services.AddTransient<IDeleteTodoRepo, DeleteTodoRepo>();
            Services.AddTransient<ITodoFilterRepo, TodoFilterRepo>();
            Services.AddTransient<ILoginRepo, LoginRepo>();
            Services.AddTransient<IGetAllTodosService, GetAllTodosService>();
            Services.AddTransient<IAddTodoService, AddTodoService>();
            Services.AddTransient<IUpdateTodoService, UpdateTodoService>();
            Services.AddTransient<IDeleteTodoService, DeleteTodoService>();
            Services.AddTransient<ITodoFilterService, TodoFilterService>();
            Services.AddTransient<ILoginService, LoginService>();
        }
    }
}


