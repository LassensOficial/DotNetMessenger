using DotNetMessenger.Application.Repositories;
using DotNetMessenger.Infrastructure.Data;
using DotNetMessenger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class SendMessageRepository(ApplicationDbContext db) : IMessageRepository
{
    public async Task<bool> SendMessage(SendMessangeCommand command)
    {
        try
        {        
            Message message = new()
            {
                Id = 0,
                ChatId = command.Message.ChatId,
                OwnerId = command.Message.OwnerId,
                Context = command.Message.Context,
                CreatedTime = DateTime.UtcNow
            };

            await db.Messages.AddAsync(message);
            await db.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            return false;
        }

        // return await db.Messages.AnyAsync(m => m.Context == command.Message.Context);
        return true;
    }
}