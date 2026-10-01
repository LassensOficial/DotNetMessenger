using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using MediatR;

public class CreateChatCommandHandler(IChatsRepository chatsRepository, IUserRepository userRepository) : IRequestHandler<CreateChatCommand, int>
{
    public async Task<int> Handle(CreateChatCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await userRepository.ExistsByNameAsync(command.Name, cancellationToken);
        bool sessionKeyIsCorrect = await userRepository.ExistsBySessionKey(command.SessionKey, cancellationToken);

        if (userFound && sessionKeyIsCorrect)
        {
            List<string> usersNameInChat = new List<string>()
            {
                command.Name,
                await userRepository.GetNameBySessionKeyAsync(command.SessionKey, cancellationToken)
            };

            List<int> usersIdInChat = new List<int>()
            {
                await userRepository.GetIdByNameAsync(usersNameInChat[0], cancellationToken),
                await userRepository.GetIdByNameAsync(usersNameInChat[1], cancellationToken)
            };

            Chat chat = new Chat
            {
                UsersIdInChat = usersIdInChat,
                UserNameInChat = usersNameInChat
            };

            await chatsRepository.AddAsync(chat);

            return chat.Id;
        }
        else
            throw new Exception("Ошибка, userFound = false or sessionKey not correct");
    }
}