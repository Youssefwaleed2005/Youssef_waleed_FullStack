using Assignment_2.Repo;
using Assignment_2.Services;
using Assignment_3.Data;
using Assignment_3.MiddleWare;
using Assignment_3.Repo;
using Assignment_3.Services;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Mappings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IProductRepos,ProductRepo>();
builder.Services.AddScoped<IProductServices,ProductService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService,UserService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});


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
