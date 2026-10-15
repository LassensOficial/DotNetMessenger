using System.Data.Common;
using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using MediatR;

public class CreateChatCommandHandler(IChatsRepository chatsRepository, IUserRepository userRepository) : IRequestHandler<CreateChatCommand, Chat>
{
    public async Task<Chat> Handle(CreateChatCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await userRepository.ExistsByNameAsync(command.TargetUsername, cancellationToken); // собеседник
        bool sessionKeyIsCorrect = await userRepository.ExistsBySessionKey(command.SessionKey, cancellationToken);

        List<string> userNamesInChat = new()
        {
            command.TargetUsername,
            await userRepository.GetNameBySessionKeyAsync(command.SessionKey, cancellationToken)
        };
        
        userNamesInChat.Sort();

        bool chatFound = await chatsRepository.ExistsByUserNames(userNamesInChat);

        if (userFound && sessionKeyIsCorrect && !chatFound)
        {
            List<int> usersIdInChat = new List<int>()
            {
                await userRepository.GetIdByNameAsync(userNamesInChat[0], cancellationToken),
                await userRepository.GetIdByNameAsync(userNamesInChat[1], cancellationToken)
            };

            Chat chat = new Chat
            {
                UsersIdInChat = usersIdInChat,
                UserNameInChat = userNamesInChat
            };

            await chatsRepository.AddAsync(chat);

            List<User> users = new()
            {
                await userRepository.GetByNameAsync(userNamesInChat[0],cancellationToken),
                await userRepository.GetByNameAsync(userNamesInChat[1], cancellationToken)
            };
            foreach (User user in users)
            {
                user.ChatsId.Add(chat.Id);
            }
            await userRepository.SaveChanges(cancellationToken);

            return chat;
        }
        else
            throw new Exception("Ошибка, userFound = false or sessionKey not correct");
    }
}