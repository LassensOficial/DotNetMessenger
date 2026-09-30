using MediatR;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.Commands;

public record RegisterUserCommand(string Name, string Password) : IRequest<User>;
