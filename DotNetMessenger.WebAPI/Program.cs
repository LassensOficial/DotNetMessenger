using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.CommandsHandler;
using DotNetMessenger.Infrastructure.RequestHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISqlUserLogin, SqlLoginUserRequestHandler>();
builder.Services.AddScoped<ISqlUserRegister, SqlRegisterUserRequestHandler>();
builder.Services.AddScoped<ISessionKeyCreate, SessionKey>();
builder.Services.AddScoped<ISessionRepository, SqlSessionRepositoryHandler>();
builder.Services.AddScoped<IChatsRepository, SqlChatsRepositoryRequestHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();