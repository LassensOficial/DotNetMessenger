public class ChatDto
{
    public int Id { get; set; }

    public List<int> UsersIdInChat { get; set; } = new List<int>();
    public List<string> UserNameInChat { get; set; } = new List<string>();

    public Message LastMessage { get; set; }

    public List<Message> Messages { get; set; } = new List<Message>();
}