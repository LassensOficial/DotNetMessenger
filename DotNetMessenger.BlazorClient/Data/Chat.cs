public class Chat
{
    public int Id { get; set; }

    public List<int> UsersIdInChat = new List<int>();

    public List<Message> Messages { get; set; } = new List<Message>();
}