using MediatR;
using DotNetMessenger.Domain.Entities;

public record LoginUserCommand(string Name, string Password) : IRequest<User>;
