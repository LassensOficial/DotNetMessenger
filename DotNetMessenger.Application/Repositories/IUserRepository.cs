using DotNetMessenger.Domain.Entities;

namespace DotNetMessenger.Application.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
    Task<bool> ExistsBySessionKey(string sessionKey, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task<string> GetNameBySessionKeyAsync(string sessionKey, CancellationToken cancellationToken);
    Task<int> GetIdByNameAsync(string name, CancellationToken cancellationToken);
}