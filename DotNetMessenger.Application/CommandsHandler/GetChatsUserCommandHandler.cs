using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Application.Commands;
using MediatR;

public class GetChatsUserCommandHandler(IChatsRepository chatsRepository) : IRequestHandler<GetChatsUserCommand, List<Chat>>
{
    public async Task<List<Chat>> Handle(GetChatsUserCommand command, CancellationToken cancellationToken)
    {
        return await chatsRepository.GetChats(command.key);
    }
}