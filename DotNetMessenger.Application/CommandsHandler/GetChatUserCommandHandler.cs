using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using MediatR;

public class GetChatUserCommadHandler(IChatsRepository chatRepository, IUserRepository userRepository) : IRequestHandler<GetChatUserCommand, Chat>
{
    public async Task<Chat> Handle(GetChatUserCommand command, CancellationToken cancellationToken)
    {
        bool sessionKeyCorrect = await userRepository.ExistsBySessionKey(command.SessionKey, cancellationToken);

        if (sessionKeyCorrect)
            return await chatRepository.GetChat(command.Id);
        else
            throw new Exception("Неверный ключ!");
    }
}