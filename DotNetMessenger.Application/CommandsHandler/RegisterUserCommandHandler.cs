using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.CommandsHandler;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private ISqlUserRegister _sqlUserRegister;
    private ISessionKeyCreate _sessionKeyCreate;

    public RegisterUserCommandHandler(ISqlUserRegister sqlUserRegister, ISessionKeyCreate sessionKeyCreate)
    {
        _sqlUserRegister = sqlUserRegister;
        _sessionKeyCreate = sessionKeyCreate;
    }

    public async Task<int> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await _sqlUserRegister.ExistsUserByName(command.Name);

        if (userFound)
            throw new Exception($"Пользователь с именем {command.Name} уже есть!");
        else
        {
            string sessionKey = await _sessionKeyCreate.CreateSessionKey();

            User user = new User
            {
                UserName = command.Name,
                Password = command.Password,
                SessionKey = sessionKey
            };

            await _sqlUserRegister.AddAsync(user);

            return user.Id;
        }
    }
}

public interface ISessionKeyCreate
{
    public Task<string> CreateSessionKey();
}