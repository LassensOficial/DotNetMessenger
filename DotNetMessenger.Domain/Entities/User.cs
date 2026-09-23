namespace DotNetMessenger.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string SessionKey { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<int> ChatsId { get; set; } = new List<int>();
}