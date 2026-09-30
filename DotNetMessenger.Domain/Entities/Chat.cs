namespace DotNetMessenger.Domain.Entities;

using System.ComponentModel.DataAnnotations.Schema;

public class Chat
{
    public int Id { get; set; }

    public List<int> UsersIdInChat = new List<int>();
    public List<string> UserNameInChat = new List<string>();

    public Message LastMessage { get; set; }

    [NotMapped]
    public List<Message> Messages { get; set; } = new List<Message>();
}