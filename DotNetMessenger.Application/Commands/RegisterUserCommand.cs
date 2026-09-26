using MediatR;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.Commands;

public record RegisterUserCommand(string Name, string Password) : IRequest<User>;

public interface ISqlUserRegister
{
    public Task<bool> ExistsUserByName(string name);
    public Task AddAsync(User user);
}