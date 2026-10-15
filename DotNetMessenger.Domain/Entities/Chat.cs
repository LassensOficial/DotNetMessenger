namespace DotNetMessenger.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public class Chat
{
    public int Id { get; set; }

    public List<int> UsersIdInChat { get; set; } = new List<int>();
    public List<string> UserNameInChat { get; set; } = new List<string>();

    [NotMapped]
    public List<Message> Messages { get; set; } = new List<Message>();
    [NotMapped]
    public Message LastMessage { get; set; }
}