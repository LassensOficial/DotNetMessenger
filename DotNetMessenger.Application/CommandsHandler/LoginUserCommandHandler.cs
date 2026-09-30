using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using MediatR;

namespace DotNetMessenger.Application.CommandsHandler;

public class LoginUserCommandHandler(IUserRepository userRepository) : IRequestHandler<LoginUserCommand, User>
{
    public async Task<User> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetByNameAsync(command.Name, cancellationToken);

        if (user is null)
            throw new Exception($"Пользователя с именем {command.Name} нет!");

        if (user.Password != command.Password)
            throw new Exception("Неверный пароль!");

        return user;
    }
}