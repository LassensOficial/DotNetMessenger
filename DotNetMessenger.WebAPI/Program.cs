using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.CommandsHandler;
using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Infrastructure.Data;
using DotNetMessenger.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Разрешает запросы с любого сайта
              .AllowAnyMethod()   // Разрешает любые методы (POST, GET, PUT и т.д.)
              .AllowAnyHeader();  // Разрешает любые заголовки
    });
});

string? connectionString = builder.Configuration.GetConnectionString("VPS");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Не задана строка подключения 'VPS'.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISessionKeyCreate, SessionKey>();
builder.Services.AddScoped<ISessionRepository, SqlSessionRepositoryHandler>();
builder.Services.AddScoped<IChatsRepository, SqlChatsRepositoryRequestHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetChatsUserCommand).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();