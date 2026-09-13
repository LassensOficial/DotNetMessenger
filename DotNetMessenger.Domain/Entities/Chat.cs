namespace DotNetMessenger.Domain.Entities;

public class Chat
{
    public int Id { get; set; }

    public int FirstUserId { get; set; }
    public int SecondUserId { get; set; }
}