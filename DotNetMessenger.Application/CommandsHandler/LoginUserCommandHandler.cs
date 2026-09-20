namespace DotNetMessenger.Application.CommandsHandler;

using MediatR;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, int>
{
    private ISqlUserLogin _sqlUserLogin;
    public LoginUserCommandHandler(ISqlUserLogin sqlUserLogin)
    {
        _sqlUserLogin = sqlUserLogin;
    }

    public async Task<int> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await _sqlUserLogin.ExistsUserByName(command.Name);

        if (userFound)
        {
            int userId = await _sqlUserLogin.GetUserId(command.Name);

            return userId;
        }
        else
            throw new Exception($"Пользователя с именем {command.Name} нет!");
    }
}