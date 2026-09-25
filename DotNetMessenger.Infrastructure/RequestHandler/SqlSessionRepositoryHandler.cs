using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SqlSessionRepositoryHandler(ApplicationDbContext db) : ISessionRepository
{

    public async Task<bool> ExistsSessionKey(string key)
    {
        return await db.Users.AnyAsync(u => u.SessionKey == key);
    }
}
