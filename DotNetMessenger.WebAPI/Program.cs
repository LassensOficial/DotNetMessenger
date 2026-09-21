using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.CommandsHandler;
using DotNetMessenger.Infrastructure.RequestHandler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISqlUserLogin, SqlLoginUserRequestHandler>();
builder.Services.AddScoped<ISqlUserRegister, SqlRegisterUserRequestHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommand>();
    cfg.RegisterServicesFromAssemblyContaining<RegisterUserCommandHandler>();

    cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>();
    cfg.RegisterServicesFromAssemblyContaining<LoginUserCommandHandler>();
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