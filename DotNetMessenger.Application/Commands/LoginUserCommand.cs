using MediatR;

public record LoginUserCommand(string Name, string Password) : IRequest<int>;

public interface ISqlUserLogin
{
    public Task<bool> ExistsUserByName(string name);

    public Task<int> GetUserId(string name);
}