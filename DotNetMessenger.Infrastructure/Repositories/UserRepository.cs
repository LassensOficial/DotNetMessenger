using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNetMessenger.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext db) : IUserRepository
{
    public Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
    {
        return db.Users.AnyAsync(u => u.UserName == name, cancellationToken);
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
