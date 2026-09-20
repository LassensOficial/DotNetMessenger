using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetMessenger.Infrastructure.RequestHandler;

public class SqlLoginUserRequestHandler : ISqlUserLogin
{
    public async Task<bool> ExistsUserByName(string name)
    {
        using (var db = new ApplicationDbContext("VPS"))
        {
            return await db.Users.AnyAsync(u => u.UserName == name);
        }
    }

    public async Task<int> GetUserId(string name)
    {
        using (var db = new ApplicationDbContext("VPS"))
        {
            User user = await db.Users.Where(u => u.UserName == name).FirstOrDefaultAsync();

            return user.Id;
        }
    }
}