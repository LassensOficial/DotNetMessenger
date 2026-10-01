using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SessionKeyRepository(ApplicationDbContext db) : ISessionKeyRepository
{

    public async Task<bool> ExistsSessionKey(string key)
    {
        return await db.Users.AnyAsync(u => u.SessionKey == key);
    }
}
