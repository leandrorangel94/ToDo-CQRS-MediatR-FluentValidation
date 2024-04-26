using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDo.Api.Configuracao;
using ToDo.Application;
using ToDo.Infra.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoDbContext>(opt => opt.UseNpgsql(builder.Configuration
                                                                          .GetConnectionString("connectionString")));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo.Api", Version = "v1" });
});

//builder.Services.BuildServiceProvider()
//                .GetService<ToDoDbContext>().Database
//                .Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo.Api v1"));
}


app.UseHttpsRedirection();
app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.UseMiddleware(typeof(ExceptionMiddleware));

app.Run();
public partial class Program { }