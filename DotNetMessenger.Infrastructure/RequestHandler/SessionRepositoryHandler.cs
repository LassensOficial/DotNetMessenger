using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SessionRepositoryHandler : ISessionRepository
{
    public async Task<bool> ExistsSessionKey(string key)
    {
        using(var db = new ApplicationDbContext("VPS"))
        {
            return await db.Users.AnyAsync(u => u.SessionKey == key);
        }
    }
}