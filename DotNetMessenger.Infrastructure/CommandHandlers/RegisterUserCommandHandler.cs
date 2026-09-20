using MediatR;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;

namespace DotNetMessenger.Infrastructure.CommandHandlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
{
    public Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        using var db = new ApplicationDbContext("VPS");
        var userFound = db.Users.Where(u => u.UserName.Equals(request.Name));

        if (userFound != null)
        {
            var newUser = new User
            {
                UserName = request.Name,
                CreatedAt = DateTime.Now
            };

            db.Add(newUser);
            db.SaveChanges();
        }

        return Task.CompletedTask;
    }
}
