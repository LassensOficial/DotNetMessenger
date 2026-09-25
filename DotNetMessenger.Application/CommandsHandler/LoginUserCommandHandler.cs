namespace DotNetMessenger.Application.CommandsHandler;

using MediatR;

public class LoginUserCommandHandler(ISqlUserLogin sqlUserLogin) : IRequestHandler<LoginUserCommand, int>
{
    public async Task<int> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await sqlUserLogin.ExistsUserByName(command.Name);

        if (userFound)
        {
            int userId = await sqlUserLogin.GetUserId(command.Name);

            return userId;
        }
        else
            throw new Exception($"Пользователя с именем {command.Name} нет!");
    }
}