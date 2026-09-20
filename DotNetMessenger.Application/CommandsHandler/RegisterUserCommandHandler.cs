using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Infrastructure.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    public Task Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        
    }
}
