using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
var allowedCorsOrigins =
    builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>() 
    ?? Array.Empty<string>();

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policyBuilder => 
            policyBuilder
                .WithOrigins(allowedCorsOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod());
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services
    .AddDbContext<ToDoDbContext>(options => 
        //options.UseInMemoryDatabase("ToDo")); // To use InMemory Database
        options.UseSqlite( builder.Configuration.GetConnectionString("SqliteDatabase"))); // To use Sqlite
builder.Services.AddAutoMapper(options => options.AddProfile(new ToDoMapperProfile()));
builder.Services.AddScoped<ITodoRepository, ToDoRepository>();

var app = builder.Build();

// Use cors shall be called before adding any API
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers()
    .WithOpenApi();

// Automatic migrations can be unreliable for production scenarios and large database schemas.
// Also it does not feel right for webapp to handle database deployment.
using var scope = app.Services.CreateScope();
using var toDoDataContext = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
//toDoDataContext?.Database.EnsureCreated(); // Use for In-memory database
toDoDataContext?.Database.Migrate(); // For relational databases

app.Run();