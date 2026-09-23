namespace DotNetMessenger.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public class Chat
{
    public int Id { get; set; }

    public int FirstUserId { get; set; }
    public int SecondUserId { get; set; }

    [NotMapped]
    public List<Message> Messages { get; set; } = new List<Message>();
}