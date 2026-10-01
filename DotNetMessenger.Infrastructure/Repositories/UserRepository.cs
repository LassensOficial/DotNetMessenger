using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetMessenger.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext db) : IUserRepository
{
    public async Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return await db.Users.AnyAsync(u => u.UserName == name, cancellationToken);
    }

    public async Task<bool> ExistsBySessionKey(string sessionKey, CancellationToken cancellationToken)
    {
        return await db.Users.Where(u => u.SessionKey == sessionKey).AnyAsync();
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await db.Users.AddAsync(user, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return db.Users.FirstOrDefaultAsync(u => u.UserName == name, cancellationToken);
    }
}
