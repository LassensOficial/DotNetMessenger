namespace DotNetMessenger.Infrastructure.RequestHandler;

using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SqlRegisterUserRequestHandler : ISqlUserRegister
{
    public async Task<bool> ExistsUserByName(string name)
    {
        using (var db = new ApplicationDbContext("VPS"))
        {
            return await db.Users.AnyAsync(u => u.UserName == name);
        }
    }
    
    public async Task AddAsync(User user)
    {
        using (var db = new ApplicationDbContext("VPS"))
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
}