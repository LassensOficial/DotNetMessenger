using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.CommandsHandler;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private ISqlUserRegister _sqlUserRegister;

    public RegisterUserCommandHandler(ISqlUserRegister sqlUserRegister)
    {
        _sqlUserRegister = sqlUserRegister;
    }

    public async Task<int> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await _sqlUserRegister.ExistsUserByName(command.Name);

        if (userFound)
            throw new Exception($"Пользователь с именем {command.Name} уже есть!");
        else
        {
            User user = new User
            {
                UserName = command.Name,
                Password = command.Password
            };

            await _sqlUserRegister.AddAsync(user);

            return user.Id;
        }
    }
}
