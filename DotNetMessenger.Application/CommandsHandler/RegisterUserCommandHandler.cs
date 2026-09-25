using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.CommandsHandler;

public class RegisterUserCommandHandler(ISqlUserRegister sqlUserRegister, ISessionKeyCreate sessionKeyCreate) : IRequestHandler<RegisterUserCommand, int>
{
    public async Task<int> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        bool userFound = await sqlUserRegister.ExistsUserByName(command.Name);

        if (userFound)
            throw new Exception($"Пользователь с именем {command.Name} уже есть!");
        else
        {
            string sessionKey = await sessionKeyCreate.CreateSessionKey();

            User user = new User
            {
                UserName = command.Name,
                Password = command.Password,
                SessionKey = sessionKey
            };

            await sqlUserRegister.AddAsync(user);

            return user.Id;
        }
    }
}

public interface ISessionKeyCreate
{
    public Task<string> CreateSessionKey();
}