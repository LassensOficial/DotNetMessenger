using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
