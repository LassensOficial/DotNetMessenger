using DotNetMessenger.Domain.Entities;

public interface IChatsRepository
{
    public Task<List<Chat>> GetChats(string key);
    public Task<Chat> GetChat(int id);
}