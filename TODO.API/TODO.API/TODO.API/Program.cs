using TODO.API.Repository.Implementation;
using TODO.API.Repository.Interface;
using TODO.API.Services.Implementation;
using TODO.API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your repository and service implementations

// Dependency Injection For Repository
builder.Services.AddTransient<IGetAllTodosRepo, GetAllTodosRepo>();
builder.Services.AddTransient<IAddTodoRepo, AddTodoRepo>();
builder.Services.AddTransient<IUpdateTodoRepo, UpdateTodoRepo>();
builder.Services.AddTransient<IDeleteTodoRepo , DeleteTodoRepo>();
builder.Services.AddTransient<ITodoFilterRepo, TodoFilterRepo>();

// Dependency Injection for Servise
builder.Services.AddTransient<IGetAllTodosService, GetAllTodosService>();
builder.Services.AddTransient<IAddTodoService, AddTodoService>();
builder.Services.AddTransient<IUpdateTodoService, UpdateTodoService>();
builder.Services.AddTransient<IDeleteTodoService, DeleteTodoService>();
builder.Services.AddTransient<ITodoFilterService, TodoFilterService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
