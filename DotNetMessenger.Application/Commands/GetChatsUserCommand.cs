namespace DotNetMessenger.Application.Commands;

using DotNetMessenger.Domain.Entities;
using MediatR;

public record GetChatsUserCommand(string key) : IRequest<List<Chat>>;

public interface IChatsRepository
{
    public Task<List<Chat>> GetChats(string key);
}