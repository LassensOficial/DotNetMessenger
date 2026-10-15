namespace DotNetMessenger.Application.Repositories;

using DotNetMessenger.Domain.Entities;

public interface IMessageRepository
{
    public Task<bool> SendMessage(SendMessangeCommand command);
}