using DotNetMessenger.Application.Commands;
using DotNetMessenger.Domain.Entities;
using DotNetMessenger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class SqlChatsRepositoryRequestHandler(ApplicationDbContext db) : IChatsRepository
{

    public async Task<List<Chat>> GetChats(string key)
    {
        List<int> chatsId = new List<int>();

        List<Chat> userChats = new List<Chat>();

        List<Message> messages = new List<Message>();

        chatsId = await db.Users.Where(u => u.SessionKey == key).SelectMany(u => u.ChatsId).ToListAsync();
        userChats = await db.Chats.Where(c => chatsId.Contains(c.Id)).ToListAsync();
        messages = await db.Messages.Where(u => chatsId.Contains(u.ChatId)).ToListAsync();

        foreach (Chat chat in userChats)
        {
            int chatId = chat.Id;

            foreach (Message message in messages)
            {
                if (message.ChatId == chatId)
                    chat.Messages.Add(message);
            }
        }

        return userChats;
    }
}
