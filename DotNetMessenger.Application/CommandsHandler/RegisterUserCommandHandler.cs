using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.CommandsHandler;

public class RegisterUserCommandHandler(IUserRepository userRepository, ISessionKeyCreate sessionKeyCreate) : IRequestHandler<RegisterUserCommand, User>
{
    public async Task<User> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await userRepository.ExistsByNameAsync(command.Name, cancellationToken);

        if (userFound)
            throw new Exception($"Пользователь с именем {command.Name} уже есть!");

        string sessionKey = await sessionKeyCreate.CreateSessionKey();

        User user = new User
        {
            UserName = command.Name,
            Password = command.Password,
            SessionKey = sessionKey
        };

        await userRepository.AddAsync(user, cancellationToken);

        return user;
    }
}

public interface ISessionKeyCreate
{
    public Task<string> CreateSessionKey();
}