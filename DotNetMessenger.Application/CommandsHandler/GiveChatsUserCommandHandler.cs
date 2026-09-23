using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Application.Commands;
using MediatR;

public class GiveChatsUserCommandHandler : IRequestHandler<GiveChatsUserCommand, List<Chat>>
{
    private IChatsRepository _chatsRepository;

    public GiveChatsUserCommandHandler(IChatsRepository chatsRepository)
    {
        _chatsRepository = chatsRepository;
    }

    public async Task<List<Chat>> Handle(GiveChatsUserCommand command, CancellationToken cancellationToken)
    {
        return await _chatsRepository.GetChats(command.key);
    }
}