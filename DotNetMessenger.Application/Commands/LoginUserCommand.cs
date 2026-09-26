using MediatR;
using DotNetMessenger.Domain.Entities;

public record LoginUserCommand(string Name, string Password) : IRequest<User>;

public interface ISqlUserLogin
{
    public Task<bool> ExistsUserByName(string name);

    public Task<bool> ExistsUserByPassword(string name, string password);

    public Task<User> GetUser(string name);
}