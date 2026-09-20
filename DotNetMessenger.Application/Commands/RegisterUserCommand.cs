using MediatR;

namespace DotNetMessenger.Application.Commands;

public class RegisterUserCommand : IRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
}

public interface SqlUserRepository
{
    public Task
}