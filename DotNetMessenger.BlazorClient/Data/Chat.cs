public class Chat
{
    public int Id { get; set; }

    public List<int> UsersIdInChat = new List<int>();
    public List<string> UserNameInChat = new List<string>();

    public Message LastMessage { get; set; }

    public List<Message> Messages { get; set; } = new List<Message>();
}