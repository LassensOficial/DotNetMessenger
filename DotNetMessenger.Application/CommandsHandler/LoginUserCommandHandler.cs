namespace DotNetMessenger.Application.CommandsHandler;

using DotNetMessenger.Domain.Entities;
using MediatR;

public class LoginUserCommandHandler(ISqlUserLogin sqlUserLogin) : IRequestHandler<LoginUserCommand, User>
{
    public async Task<User> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await sqlUserLogin.ExistsUserByName(command.Name);

        if (userFound)
        {
            bool passwordIsCorrect = await sqlUserLogin.ExistsUserByPassword(command.Name, command.Password);

            if (passwordIsCorrect)
            {
                User user = await sqlUserLogin.GetUser(command.Name);

                return user;
            }
            else
                throw new Exception("Неверный пароль!");
        }
        else
            throw new Exception($"Пользователя с именем {command.Name} нет!");
    }
}