using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetMessenger.Infrastructure.RequestHandler;

public class SqlLoginUserRequestHandler(ApplicationDbContext db) : ISqlUserLogin
{

    public async Task<bool> ExistsUserByName(string name)
    {
        return await db.Users.AnyAsync(u => u.UserName == name);
    }

    public async Task<int> GetUserId(string name)
    {
        User user = await db.Users.Where(u => u.UserName == name).FirstOrDefaultAsync();

        return user.Id;
    }
}
