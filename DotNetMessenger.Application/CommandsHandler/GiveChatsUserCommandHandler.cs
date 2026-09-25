using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Application.Commands;
using MediatR;

public class GiveChatsUserCommandHandler(IChatsRepository chatsRepository) : IRequestHandler<GiveChatsUserCommand, List<Chat>>
{
    public async Task<List<Chat>> Handle(GiveChatsUserCommand command, CancellationToken cancellationToken)
    {
        return await chatsRepository.GetChats(command.key);
    }
}