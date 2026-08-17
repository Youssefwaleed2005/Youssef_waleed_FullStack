using Assignment_2.Repo;
using Assignment_2.Services;
using Assignment_3.MiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProductRepos,ProductRepo>();
builder.Services.AddScoped<IProductServices,ProductService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
