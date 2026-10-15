using MediatR;
using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;

public class SendMessangeCommandHandler(IMessageRepository messageRepository) : IRequestHandler<SendMessangeCommand, bool>
{
    public async Task<bool> Handle(SendMessangeCommand command, CancellationToken cancellationToken)
    {
        return await messageRepository.SendMessage(command);
    }
}
