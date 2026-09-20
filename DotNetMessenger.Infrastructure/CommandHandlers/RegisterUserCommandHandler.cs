using DotNetMessenger.Infrastructure.Data;
using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;

class RegisterUserCommandHandler(RegisterUserCommand registerUserCommand)
{
    public void Registration()
    {
        using (var db = new ApplicationDbContext("VPS"))
        {
            var userFound = db.Users.Where(u => u.UserName.Equals(registerUserCommand.Name));

            if (userFound != null)
            {
                User newUser = new User()
                {
                    UserName = registerUserCommand.Name,
                    CreatedAt = DateTime.Now
                };

                db.Add(newUser);
                db.SaveChanges();
            }

        }
    }

}