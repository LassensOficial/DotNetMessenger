namespace DotNetMessenger.Domain.Entities;

public class Message
{
    public int Id { get; set; }

    public int ChatId { get; set; }

    public int OwnerId { get; set; }
    public string Context { get; set; }

    public DateTime CreatedTime { get; set; }
}